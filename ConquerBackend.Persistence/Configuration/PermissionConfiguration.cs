using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Persistence.Configuration
{
    using ConquerBackend.Domain.Entities.ConquerBackend;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PermissionsConfiguration : IEntityTypeConfiguration<PermissionsModel>
    {
        public void Configure(EntityTypeBuilder<PermissionsModel> builder)
        {
            // Cấu hình bảng Permissions
            builder.ToTable("Permissions");

            // Cấu hình RoleId
            builder.Property(p => p.RoleId)
                .HasColumnName("ROLEID")
                .IsRequired();  // RoleId là bắt buộc

            // Cấu hình FunctionId
            builder.Property(p => p.FunctionId)
                .HasColumnName("FUNCTIONID")
                .IsRequired();  // FunctionId là bắt buộc

            // Cấu hình ActionId
            builder.Property(p => p.ActionId)
                .HasColumnName("ACTIONID")
                .IsRequired();  // ActionId là bắt buộc
        }
    }

}
