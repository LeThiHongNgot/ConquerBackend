namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class ActionsModel : FullAuditedEntity<Guid>,Active
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActived { get; set; }
        public virtual ICollection<PermissionsModel> Permissions { get; set; }
        public virtual ICollection<ActionInFunctionModel> ActionInFunctions { get; set; }
    }
}
