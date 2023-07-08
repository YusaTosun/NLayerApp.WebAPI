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
    public class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature()
            {
                Id=1,
                Color="Kırmızı",
                Height=100,
                Width=100,
                ProductId=1
            },
                 new ProductFeature()
            {
                Id=2,
                Color="Mavi",
                Height=100,
                Width=200,
                ProductId=1
            },
                 new ProductFeature()
            {
                Id=1,
                Color="Yeşil",
                Height=100,
                Width=300,
                ProductId=2
            }
            
            );
        }
    }
}
