using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public abstract class BaseEntity<TKey>: IHasKey<TKey>
    {
        [Column("ID")]
        public TKey Id { get; set; }    
    }

    public abstract class Entity<TKey>: BaseEntity<TKey>
    {
        [Column("CREATEDDATE")]
        public virtual DateTime? CreatedDate { get; set; }

        [Column("UPDATEDDATE")]
        public virtual DateTime? UpdatedDate { get; set; }
    }    

}
