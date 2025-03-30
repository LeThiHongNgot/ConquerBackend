using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Persistence.Configuration
{
    using ConquerBackend.Domain.Entities.ConquerBackend;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RolesConfiguration : IEntityTypeConfiguration<RolesModel>
    {
        public void Configure(EntityTypeBuilder<RolesModel> builder)
        {
            // Cấu hình bảng Roles
            builder.ToTable("Roles");

            // Cấu hình tên Role
            builder.Property(r => r.Name)
                .HasColumnName("ROLENAME")
                .IsRequired() // Nếu bạn muốn trường này là bắt buộc
                .HasMaxLength(256); // Tên role có thể có độ dài tối đa 256 ký tự (theo mặc định của Identity)

            // Cấu hình Description
            builder.Property(r => r.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(500) // Giới hạn độ dài của Description
                .IsRequired(false); // Nếu không bắt buộc thì bỏ IsRequired

            // Cấu hình RoleCode
            builder.Property(r => r.RoleCode)
                .HasColumnName("ROLECODE")
                .HasMaxLength(100)
                .IsRequired();

            // Cấu hình CreatedBy
            builder.Property(r => r.CreatedBy)
                .HasColumnName("CREATEDBY")
                .HasMaxLength(200)
                .IsRequired(false);

            // Cấu hình CreatedAt
            builder.Property(r => r.CreatedAt)
                .HasColumnName("CREATEDDATE")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()"); // Đặt mặc định là giờ UTC khi không có giá trị.

            // Cấu hình OrderId
            builder.Property(r => r.OrderId)
                .HasColumnName("ORDERID")
                .ValueGeneratedOnAdd() // OrderId tự động tăng
                .IsRequired();

            // Cấu hình IsDeleted
            builder.Property(r => r.IsDeleted)
                .HasColumnName("ISDELETED")
                .IsRequired()
                .HasDefaultValue(false); // Mặc định IsDeleted là false

            // Cấu hình các thuộc tính từ FullAuditedEntity (CreatedBy, CreatedAt...)
            builder.Property(r => r.CreatedBy)
                .HasColumnName("CREATEDBY")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(r => r.CreatedAt)
                .HasColumnName("CREATEDDATE")
                .IsRequired(false)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }

}
