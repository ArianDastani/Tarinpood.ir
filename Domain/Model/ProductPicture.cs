using System;
using System.Collections.Generic;

namespace Persistance.Context;

public partial class ProductPicture
{
    public int ProductPictureId { get; set; }

    public string ProductPictureFilePath { get; set; } = null!;

    public int? ProductId { get; set; }

    public DateTime? InsertDate { get; set; }

    public byte? IsRemove { get; set; }

    public DateTime? RemoveDate { get; set; }

    public virtual Product? Product { get; set; }
}
