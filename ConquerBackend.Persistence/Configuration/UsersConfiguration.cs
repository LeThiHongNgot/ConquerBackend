using ConquerBackend.Domain.Entities.ConquerBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsersConfiguration : IEntityTypeConfiguration<UsersModel>
{
    public void Configure(EntityTypeBuilder<UsersModel> builder)
    {
        // Cấu hình bảng Users
        builder.ToTable("Users");

        // Cấu hình FirstName
        builder.Property(u => u.FirstName)
            .HasColumnName("FIRSTNAME")
            .IsRequired()
            .HasMaxLength(100);

        // Cấu hình LastName
        builder.Property(u => u.LastName)
            .HasColumnName("LASTNAME")
            .IsRequired()
            .HasMaxLength(100);

        // Cấu hình FullName
        builder.Property(u => u.FullName)
            .HasColumnName("FULLNAME")
            .HasMaxLength(200);

        // Cấu hình DateOfBirth
        builder.Property(u => u.DateOfBirth)
            .HasColumnName("DATEOFBIRTH")
            .IsRequired();

        // Cấu hình IsDirector
        builder.Property(u => u.IsDirector)
            .HasColumnName("ISDIRECTOR")
            .IsRequired();

        // Cấu hình IsHeadOfDepartment
        builder.Property(u => u.IsHeadOfDepartment)
            .HasColumnName("ISHEADOFDEPARTMENT")
            .IsRequired();

        // Cấu hình ManagerId (ForeignKey)
        builder.Property(u => u.ManagerId)
            .HasColumnName("MANAGERID")
            .IsRequired();

        // Cấu hình PositionId (ForeignKey)
        builder.Property(u => u.PositionId)
            .HasColumnName("POSITIONID")
            .IsRequired();

        // Cấu hình các thuộc tính từ FullAuditedEntity
        builder.Property(u => u.CreatedAt)
            .HasColumnName("CREATEAT")
            .IsRequired();

        builder.Property(u => u.ModifiedAt)
            .HasColumnName("MODIFIEDAT")
            .IsRequired(false);

        builder.Property(u => u.CreatedBy)
            .HasColumnName("CREATEDBY")
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(u => u.ModifiedBy)
            .HasColumnName("MODIFIEDBY")
            .HasMaxLength(200)
            .IsRequired(false);
    }
}
