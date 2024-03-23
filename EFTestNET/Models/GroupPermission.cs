using System;
using System.Collections.Generic;

#nullable disable

namespace EFTestNET.Models
{
    public partial class GroupPermission
    {
        public int GroupId { get; set; }
        public int PermissionId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
