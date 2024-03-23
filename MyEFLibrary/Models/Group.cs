using System;
using System.Collections.Generic;

namespace MyEFLibrary.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
