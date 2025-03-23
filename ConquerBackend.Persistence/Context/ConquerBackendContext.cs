using ConquerBackend.Application.Common;
using ConquerBackend.Domain.Entities;
using ConquerBackend.Domain.Entities.ConquerBackend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ConquerBackend.Persistence.Context
{
    public class ConquerBackendContext:DbContext
    {
        public ConquerBackendContext()
        {
        }

        public ConquerBackendContext(DbContextOptions<ConquerBackendContext> options)
            : base(options)
        {
        }
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<RolesModel> Roles { get; set; }
        public DbSet<ActionsModel> Action { get; set; }
        public DbSet<PermissionsModel> Permissions { get; set; }
        public DbSet<FunctionsModel> Functions { get; set; }
        //public DbSet<UserClaimsModel> UserClaims { get; set; }
        //public DbSet<UserTokensModel>  UserTokens { get; set; }
        public DbSet<ActionInFunctionModel> ActionInFunction { get; set; }
        //public DbSet<UserLoginsModel> UserLogins { get; set; }
        //public DbSet<UserRolesModel> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SPFVRCD;Initial Catalog=CONQUERBACKEND;Integrated Security=True;Trust Server Certificate=True",
                b => b.MigrationsAssembly("ConquerBackend.Persistence"));  // Thêm MigrationsAssembly 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(AppConstants.DbSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var softDeleteEntities = typeof(ISoftDelete).Assembly.GetTypes()
                    .Where(type => typeof(ISoftDelete)
                                    .IsAssignableFrom(type)
                                    && type.IsClass
                                    && !type.IsAbstract);

            foreach (var softDeleteEntity in softDeleteEntities)
            {
                modelBuilder.Entity(softDeleteEntity).HasQueryFilter(CreateSoftDeleteFilterExpression(softDeleteEntity));
            }
        }
        //lọc các đôi tượng bị xóa đi
       private static LambdaExpression? CreateSoftDeleteFilterExpression(Type type)
    {
        var parameter = Expression.Parameter(type, "ld");// khởi tạo tham chiếu lamda
        var falseConstantValue = Expression.Constant(false);
        var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDeleted));
        var equalExpression = Expression.Equal(propertyAccess, falseConstantValue);// biểu thức so sánh chỉ lấy những giá trị chưa bị xóa mềm
        var lambda = Expression.Lambda(equalExpression, parameter); //tạo biểu thức lamda

        return lambda;
    }


    }
}
