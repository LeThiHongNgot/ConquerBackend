namespace ConquerBackend.Domain.Entities
{
    public interface IHasUpdateTime
    {
       DateTime? ModifiedAt { get; set; }
    }
}
