using System;
using System.Collections.Generic;

#nullable disable

namespace EFTestNET.Models
{
    public partial class Permission
    {
        public Permission()
        {
            GroupPermissions = new HashSet<GroupPermission>();
        }

        public int Id { get; set; }
        public string Permission1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}
