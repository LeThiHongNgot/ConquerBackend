using System.ComponentModel.DataAnnotations.Schema;

namespace ConquerBackend.Domain.Entities
{
    public interface IHasKey<TKey>  // is Generic Type  giúp tái sử dụng (resusable)
    {
        [Column("ID")]
        TKey Id { get; set; }
    }
}
    