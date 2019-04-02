using AutoMapper;
using WebStoreAPI.Commands.Products;
using WebStoreAPI.Commands.Users;
using WebStoreAPI.Models;

namespace WebStoreAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateUserCommand, User>();
        }
    }
}
