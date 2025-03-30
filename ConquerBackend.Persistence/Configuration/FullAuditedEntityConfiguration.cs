using ConquerBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class FullAuditedEntityConfiguration<TKEY> : IEntityTypeConfiguration<FullAuditedEntity<TKEY>>
{
    public void Configure(EntityTypeBuilder<FullAuditedEntity<TKEY>> builder)
    {
        // Cấu hình CreatedBy
        builder.Property(e => e.CreatedBy)
            .HasColumnName("CREATEDBY")
            .HasMaxLength(200)
            .IsRequired(false);

        // Cấu hình CreatedAt (Ngày tạo)
        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATEAT")
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

        // Cấu hình ModifiedBy
        builder.Property(e => e.ModifiedBy)
            .HasColumnName("MODIFIEDBY")
            .HasMaxLength(200)
            .IsRequired(false);

        // Cấu hình ID
        builder.Property(e => e.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd()
            .IsRequired();

        // Cấu hình IsDeleted
        builder.Property(e => e.IsDeleted)
            .HasColumnName("ISDELETED")
            .HasDefaultValue(false)
            .IsRequired();

        // Cấu hình OrderId
        builder.Property(e => e.OrderId)
            .HasColumnName("ORDERID")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}
