using System;
using System.Collections.Generic;

namespace Persistance.Context;

public partial class MainSlider
{
    public int SliderId { get; set; }

    public string SliderPicture { get; set; } = null!;

    public string? SliderH2Content { get; set; }

    public string? SliderH5Content { get; set; }

    public int? SliderOrder { get; set; }
}
