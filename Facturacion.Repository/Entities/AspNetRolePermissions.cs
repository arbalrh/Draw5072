using System;
using Microsoft.AspNetCore.Identity;

namespace Facturacion.Repository.Entities
{
    public class AspNetRolePermissions
    {
        public AspNetRolePermissions()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string IdentityRoleId { get; set; }
        public IdentityRole AspNetRole { get; set; }
        public Guid PermissionId { get; set; }
        public AspNetPermissions Permission { get; set; }
        public string CreateUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
