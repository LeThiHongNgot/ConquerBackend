using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public interface IHasKey<TKey>  // is Generic Type  giúp tái sử dụng (resusable)
    {
        [Column("ID")]
        TKey Id { get; set; }
    }
}
    