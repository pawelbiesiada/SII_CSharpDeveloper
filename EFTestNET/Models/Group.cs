using System;
using System.Collections.Generic;

#nullable disable

namespace EFTestNET.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupPermissions = new HashSet<GroupPermission>();
            UserGroups = new HashSet<UserGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
