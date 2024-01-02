namespace Application.Services.Product.Querise.IGetAllProductForAdminService;

public class ResultGetProductForAdminDto
{
    public int? ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductMainPicture { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? InsertDate { get; set; }
}