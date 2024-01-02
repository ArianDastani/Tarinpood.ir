using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = Persistance.Context.Attribute;

namespace Application.InterFace
{
    public interface IDatabaseContext
    {
         DbSet<Asste> Asstes { get; set; }

         DbSet<Attribute> Attributes { get; set; }

         DbSet<Category> Categories { get; set; }

         DbSet<MainSlider> MainSliders { get; set; }

         DbSet<Product> Products { get; set; }

         DbSet<ProductAttribute> ProductAttributes { get; set; }

         DbSet<ProductPicture> ProductPictures { get; set; }

         DbSet<Role> Roles { get; set; }

         DbSet<User> Users { get; set; }


        int SaveChanges(bool acceptAllChangeOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangeOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
