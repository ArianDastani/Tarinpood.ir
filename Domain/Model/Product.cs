
namespace Persistance.Context;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public string ProductMainPicture { get; set; } = null!;

    public int? UId { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? InsertDate { get; set; }

    public bool? IsRemove { get; set; }=false;

    public DateTime? RemoveDate { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();

    public virtual User? UIdNavigation { get; set; }
}
