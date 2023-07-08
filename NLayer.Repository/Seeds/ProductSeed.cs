using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product()
            {
                Id = 1,
                CategoryId = 1,
                Price = 100,
                Name = "Kalem1",
                Stock = 20,
                CreatedDate = DateTime.Now,

            },
            new Product()
            {
                Id = 2,
                CategoryId = 1,
                Name = "Kalem2",
                Price = 200,
                Stock = 30,
                CreatedDate = DateTime.Now,

            },
            new Product()
            {
                Id = 3,
                CategoryId = 1,
                Name = "Kalem3",
                Price = 150,
                Stock = 50,
                CreatedDate = DateTime.Now,

            },
             new Product()
             {
                 Id = 4,
                 CategoryId = 2,
                 Name = "Kitap1",
                 Price = 550,
                 Stock = 50,
                 CreatedDate = DateTime.Now,

             }

            );
        }
    }
}
