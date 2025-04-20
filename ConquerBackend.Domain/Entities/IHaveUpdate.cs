namespace ConquerBackend.Domain.Entities
{
    public interface IHaveUpdate
    {
        string?  ModifiedBy { get; }
    }
}
