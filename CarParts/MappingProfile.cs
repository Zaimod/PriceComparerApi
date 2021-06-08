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
            CreateMap<UserDto, User>()
                .ForMember(vm => vm.UserName, mpvm => mpvm.MapFrom(u => u.UserName))
                .ForMember(vm => vm.FirstName, mpvm => mpvm.MapFrom(u => u.FirstName))
                .ForMember(vm => vm.LastName, mpvm => mpvm.MapFrom(u => u.LastName))
                .ForMember(vm => vm.Birthday, mpvm => mpvm.MapFrom(u => u.Birthday))
                .ForMember(vm => vm.City, mpvm => mpvm.MapFrom(u => u.City))
                .ForMember(vm => vm.Sex, mpvm => mpvm.MapFrom(u => u.Sex))
                .ForMember(vm => vm.PhoneNumber, mpvm => mpvm.MapFrom(u => u.PhoneNumber))
                .ForMember(vm => vm.Email, mpvm => mpvm.MapFrom(u => u.Email))
                .ReverseMap();
        }
    }
}
