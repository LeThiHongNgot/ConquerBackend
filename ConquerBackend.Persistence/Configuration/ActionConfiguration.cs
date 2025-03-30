using ConquerBackend.Domain.Entities.ConquerBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Persistence.Configuration
{
    public class ActionsConfiguration : IEntityTypeConfiguration<ActionsModel>
    {
        public void Configure(EntityTypeBuilder<ActionsModel> builder)
        {
            // Cấu hình bảng Actions (nếu cần đổi tên bảng)
            builder.ToTable("Actions");

            // Cấu hình cột Name
            builder.Property(a => a.Name)
                .HasColumnName("NAME")
                .IsRequired()
                .HasMaxLength(200);  // Giới hạn độ dài

            // Cấu hình cột Code
            builder.Property(a => a.Code)
                .HasColumnName("CODE")
                .IsRequired()
                .HasMaxLength(50);  // Giới hạn độ dài

            // Cấu hình cột IsActived
            builder.Property(a => a.IsActived)
                .HasColumnName("ISACTIVED")
                .IsRequired()
                .HasDefaultValue(true);  // Mặc định là true
        }
    }
    
}
