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
            CreateMap<Cars, CarsDto>();
            CreateMap<Suppliers, SuppliersDto>();
            CreateMap<Parts, PartsDto>();
            CreateMap<Category, CategoryDto>();

            CreateMap<CarForCreationDto, Cars>();
            CreateMap<SupplierForCreationDto, Suppliers>();
            CreateMap<PartsForCreationDto, Parts>();
            CreateMap<CategoryForCreationDto, Category>();
        }
    }
}
