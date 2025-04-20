namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class FunctionsModel : FullAuditedEntity<Guid>, Active
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string CssClass { get; set; }
        public bool IsActived { get; set; }
        public virtual ICollection<PermissionsModel> Permissions { get; set; }
        public virtual ICollection<ActionInFunctionModel> ActionInFunctions { get; set; }
    }
}
