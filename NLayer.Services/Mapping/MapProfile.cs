﻿using AutoMapper;
using NLayer.Core.Models;
using NLayer.Core.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Services.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<ProductFeature,ProductFeatureDTO>().ReverseMap();
            //CreateMap<ProductUpdate, ProductUpdateDTO>().ReverseMap();
            

        }
    }
}
