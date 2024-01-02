namespace Application.Services.Product.Querise.IGetProductForIndexService;

public class GetProductForIndexDto
{
    public int? ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductMainPicture { get; set; }

    public List<AttributeIndexDto>? ProductAttributes { get; set; }

    public List<GetProductForIndexDto>? LastProduct { get; set; }
}