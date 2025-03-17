using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Domain.Entities
{
    public interface IHasKey<T>// is Generic Type  giúp tái sử dụng (resusable)
    {
        [Column("ID")]
        T Id { get; set; }
    }
}
