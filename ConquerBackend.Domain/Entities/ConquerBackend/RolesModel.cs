﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConquerBackend.Domain.Entities.ConquerBackend
{
    public class RolesModel : IdentityRole<Guid>, IHasCreationTime, IHaveCreator, OrderIdEntity, ISoftDelete, IHasKey<Guid>
    {
        public string Description { get; set; }
        public string RoleCode { get; set; }

        [Column("CREATEDBY")]
        [MaxLength(200)]
        public virtual string CreatedBy { get; set; } = string.Empty;

        [Column("CREATEDDATE")]
        public virtual DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("ORDERID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // OrderId tự động tăng
        public virtual long OrderId { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual ICollection<PermissionsModel> Permissions { get; set; }
    }
}
