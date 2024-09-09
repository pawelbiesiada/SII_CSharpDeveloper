using System;
using System.Collections.Generic;

#nullable disable

namespace EFTestNET.Models
{
    public partial class User
    {
        public User()
        {
            UserGroups = new HashSet<UserGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
