using System;
using System.Collections.Generic;

namespace Persistance.Context;

public partial class Asste
{
    public int AssetId { get; set; }

    public string AssetFilePath { get; set; } = null!;

    public string? AssetType { get; set; }

    public int? UId { get; set; }

    public DateTime? InsertDate { get; set; }

    public byte? IsRemove { get; set; }

    public DateTime? RemoveDate { get; set; }

    public virtual User? UIdNavigation { get; set; }
}
