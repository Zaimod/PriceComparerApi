using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, StoreDto>();
            CreateMap<Catalog, CatalogDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();

            CreateMap<StoreForCreationDto, Store>();
            CreateMap<CatalogForCreationDto, Catalog>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
