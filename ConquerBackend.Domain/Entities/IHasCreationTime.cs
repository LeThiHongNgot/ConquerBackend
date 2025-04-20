namespace ConquerBackend.Domain.Entities
{
    public interface IHasCreationTime
    {
        DateTime? CreatedAt { get; set; }
    }
}
