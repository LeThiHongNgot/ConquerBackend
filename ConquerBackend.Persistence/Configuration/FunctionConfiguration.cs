using ConquerBackend.Domain.Entities.ConquerBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FunctionsConfiguration : IEntityTypeConfiguration<FunctionsModel>
{
    public void Configure(EntityTypeBuilder<FunctionsModel> builder)
    {
        // Cấu hình bảng Functions
        builder.ToTable("Functions");

        // Cấu hình cột Name
        builder.Property(f => f.Name)
            .HasColumnName("NAME")
            .IsRequired()
            .HasMaxLength(200);  

        // Cấu hình cột Code
        builder.Property(f => f.Code)
            .HasColumnName("CODE")
            .IsRequired()
            .HasMaxLength(50);  

        // Cấu hình cột Url
        builder.Property(f => f.Url)
            .HasColumnName("URL")
            .IsRequired(false) 
            .HasMaxLength(500);  

        // Cấu hình cột CssClass
        builder.Property(f => f.CssClass)
            .HasColumnName("CSSCLASS")
            .IsRequired(false) 
            .HasMaxLength(100);  

        // Cấu hình cột IsActived
        builder.Property(f => f.IsActived)
            .HasColumnName("ISACTIVED")
            .IsRequired()
            .HasDefaultValue(true);  

    }
}
