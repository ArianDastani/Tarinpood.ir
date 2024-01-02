using System;
using System.Collections.Generic;

namespace Persistance.Context;

public partial class User
{
    public int UId { get; set; }

    public string UName { get; set; } = null!;

    public string UPassword { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UPhone { get; set; }

    public string? UProfilePicture { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; } = true;

    public DateTime? InsertDate { get; set; }

    public bool? IsRemove { get; set; } = false;

    public DateTime? RemoveDate { get; set; }

    public virtual ICollection<Asste> Asstes { get; set; } = new List<Asste>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Role? Role { get; set; }
}
