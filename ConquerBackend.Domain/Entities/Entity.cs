using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public abstract class BaseEntity<TKey> : IHasKey<TKey>
    {
        [Column("ID")]
        public TKey Id { get; set; }
    }

    public abstract class Entity<TKey> : BaseEntity<TKey>, IHasCreationTime, IHasUpdateTime
    {
        [Column("CREATEDDATE")]
        public virtual DateTime? CreatedAt { get; set; }

        [Column("UPDATEDDATE")]
        public virtual DateTime? ModifiedAt { get; set; }
    }
    public abstract class CreationAuditedEntity<TKey> : BaseEntity<TKey>, IHasCreationTime, IHaveCreator
    {
        [Column("CREATEDBY")]
        [MaxLength(200)]
        public virtual string? CreatedBy { get; set; }

        [Column("CREATEDDATE")]
        public virtual DateTime? CreatedAt { get; set; }
    }


}
