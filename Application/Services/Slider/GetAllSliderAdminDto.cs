namespace Application.Services.Slider;

public class GetAllSliderAdminDto
{
    public int SliderId { get; set; }

    public string? SliderPicture { get; set; }

    public string? SliderH2Content { get; set; }

    public string? SliderH5Content { get; set; }

    public int? SliderOrder { get; set; }
}