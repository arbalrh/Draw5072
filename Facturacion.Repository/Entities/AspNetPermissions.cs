using System;
using System.Collections.Generic;

namespace Facturacion.Repository.Entities
{
    public class AspNetPermissions
    {
        public AspNetPermissions()
        {
            InverseChildOfNavigation = new HashSet<AspNetPermissions>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? OrderNo { get; set; }
        public string ChildOf { get; set; }
        public string Navigation { get; set; }
        public string IconStyle { get; set; }
        public string CreateUserId { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public AspNetPermissions ChildOfNavigation { get; set; }
        public ICollection<AspNetPermissions> InverseChildOfNavigation { get; set; }
        public ICollection<AspNetRolePermissions> AspNetRolePermissions { get; set; }
    }
}
