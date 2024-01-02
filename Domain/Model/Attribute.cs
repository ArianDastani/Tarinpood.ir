using System;
using System.Collections.Generic;

namespace Persistance.Context;

public partial class Attribute
{
    public int AttributeId { get; set; }

    public string AttributeName { get; set; } = null!;

    public DateTime? InsertDate { get; set; }

    public bool? IsRemove { get; set; } = false;

    public DateTime? RemoveDate { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
}
