namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class PermissionsModel : BaseEntity<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid FunctionId { get; set; }
        public Guid ActionId { get; set; }
    }
}
