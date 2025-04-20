using ConquerBackend.Application.Common;
using ConquerBackend.Domain.Entities;
using ConquerBackend.Domain.Entities.ConquerBackend;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace ConquerBackend.Persistence.Context
{
    public class ConquerBackendContext : DbContext
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
        public DbSet<UserClaimsModel> UserClaims { get; set; }
        public DbSet<UserTokensModel> UserTokens { get; set; }
        public DbSet<ActionInFunctionModel> ActionInFunction { get; set; }
        public DbSet<UserLoginsModel> UserLogins { get; set; }
        public DbSet<UserRolesModel> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            base.OnModelCreating(builder);

            // Áp dụng cấu hình chung cho các Entity (Audit và Soft Delete)
            ApplyAuditConfiguration(builder);

            // Áp dụng tất cả cấu hình Entity từ Assembly
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Thêm Query Filter tự động lọc dữ liệu đã xóa mềm (Soft Delete)
            ApplyGlobalQueryFilters(builder);

            builder.HasDefaultSchema(AppConstants.DbSchema);
        }

        /// <summary>
        /// Áp dụng cấu hình audit cho các entity kế thừa FullAuditedEntity
        /// </summary>
        private static void ApplyAuditConfiguration(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(e => typeof(FullAuditedEntity<>).IsAssignableFrom(e.ClrType))
                .Select(entityType => entityType.ClrType);

            foreach (var entityType in entityTypes)
            {
                var builder = modelBuilder.Entity(entityType);

                // Kiểm tra các thuộc tính audit có tồn tại trong entity
                EnsurePropertyExists(entityType, nameof(FullAuditedEntity<Guid>.CreatedAt));
                EnsurePropertyExists(entityType, nameof(FullAuditedEntity<Guid>.CreatedBy));
                EnsurePropertyExists(entityType, nameof(FullAuditedEntity<Guid>.IsDeleted));
                EnsurePropertyExists(entityType, nameof(FullAuditedEntity<Guid>.OrderId));

                // Cấu hình các thuộc tính audit chung
                builder.Property(nameof(FullAuditedEntity<Guid>.CreatedAt))
                    .HasColumnType("datetime2")
                    .IsRequired();

                builder.Property(nameof(FullAuditedEntity<Guid>.CreatedBy))
                    .HasColumnType("VARCHAR(100)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                builder.Property(nameof(FullAuditedEntity<Guid>.IsDeleted))
                    .HasDefaultValue(false);

                builder.Property(nameof(FullAuditedEntity<Guid>.OrderId))
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                // Nếu entity có thuộc tính ModifiedBy, ModifiedAt, cấu hình các thuộc tính đó
                if (typeof(FullAuditedEntity<Guid>).IsAssignableFrom(entityType))
                {
                    builder.Property(nameof(FullAuditedEntity<Guid>.ModifiedAt))
                        .HasColumnType("datetime2")
                        .IsRequired(false);

                    builder.Property(nameof(FullAuditedEntity<Guid>.ModifiedBy))
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);
                }
            }
        }

        /// <summary>
        /// Kiểm tra entity có chứa thuộc tính hay không, nếu không thì ném exception.
        /// </summary>
        private static void EnsurePropertyExists(Type entityType, string propertyName)
        {
            if (entityType.GetProperty(propertyName) == null)
            {
                throw new InvalidOperationException($"Entity '{entityType.Name}' phải có thuộc tính '{propertyName}'.");
            }
        }

        /// <summary>
        /// Áp dụng Global Query Filters cho các entity bị xóa mềm (Soft Delete).
        /// </summary>
        private static void ApplyGlobalQueryFilters(ModelBuilder modelBuilder)
        {
            var softDeletableEntityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(entityType => typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                .Select(entityType => entityType.ClrType);

            foreach (var entityType in softDeletableEntityTypes)
            {
                var parameter = Expression.Parameter(entityType, "e");
                var filter = Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, nameof(ISoftDelete.IsDeleted)),
                        Expression.Constant(false)),
                    parameter);

                modelBuilder.Entity(entityType).HasQueryFilter(filter);
            }
        }
    }
}
