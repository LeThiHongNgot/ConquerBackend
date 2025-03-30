using ConquerBackend.Domain.Entities.ConquerBackend;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ActionInFunctionConfiguration : IEntityTypeConfiguration<ActionInFunctionModel>
{
    public void Configure(EntityTypeBuilder<ActionInFunctionModel> builder)
    {
        // Cấu hình bảng ActionInFunction (nếu cần đổi tên bảng)
        builder.ToTable("ActionInFunction");

        // Cấu hình cột RoleId
        builder.Property(a => a.RoleId)
            .HasColumnName("ROLEID")
            .IsRequired();  

        // Cấu hình cột FunctionId
        builder.Property(a => a.FunctionId)
            .HasColumnName("FUNCTIONID")
            .IsRequired();
    }
}
