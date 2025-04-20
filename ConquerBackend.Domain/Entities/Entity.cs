using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConquerBackend.Domain.Entities
{
    public abstract class BaseEntity<TKey> : IHasKey<TKey> 
    {
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
    }
    public abstract class Entity<TKey> : BaseEntity<TKey>, IHasKey<TKey>
    {

        [Column("CREATEDDATE")]
        public virtual DateTimeOffset CreatedDate { get; set; }

        [Column("UPDATEDDATE")]
        public virtual DateTimeOffset? UpdatedDate { get; set; }
    }
    public abstract class UpdateEntity<TKey> : BaseEntity<TKey>, IHaveUpdate, IHasUpdateTime
    {
        [Column("UPDATEBY")]
        [MaxLength(200)]
        public virtual string? ModifiedBy { get; set; }

        [Column("UPDATEDDATE")]
        public virtual DateTime? ModifiedAt { get; set; }
    }
    public abstract class FullAuditedEntity<TKey> : UpdateEntity<TKey> , IHasCreationTime, IHaveCreator, OrderIdEntity, ISoftDelete
    {
        [Column("CREATEDBY")]
        [MaxLength(200)]
        public virtual string CreatedBy { get; set; } =string.Empty;

        [Column("CREATEDDATE")]
        public virtual DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("ORDERID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // OrderId tự động tăng
        public virtual long OrderId { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
   
}
