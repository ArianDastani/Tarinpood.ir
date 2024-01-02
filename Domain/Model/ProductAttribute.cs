using System;
using System.Collections.Generic;

namespace Persistance.Context;

public partial class ProductAttribute
{
    public int ProductAttributeId { get; set; }

    public int? ProductId { get; set; }

    public int? AttributeId { get; set; }

    public string ProductAttributeContent { get; set; } = null!;

    public DateTime? InsertDate { get; set; }

    public virtual Attribute? Attribute { get; set; }

    public virtual Product? Product { get; set; }
}
