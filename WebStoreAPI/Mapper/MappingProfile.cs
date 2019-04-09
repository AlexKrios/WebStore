using AutoMapper;
using DataLibrary.Entities;
using WebStoreAPI.Commands.Cities;
using WebStoreAPI.Commands.Countries;
using WebStoreAPI.Commands.Deliveries;
using WebStoreAPI.Commands.Manufacturers;
using WebStoreAPI.Commands.OrderItems;
using WebStoreAPI.Commands.Orders;
using WebStoreAPI.Commands.Payments;
using WebStoreAPI.Commands.Products;
using WebStoreAPI.Commands.Roles;
using WebStoreAPI.Commands.Types;
using WebStoreAPI.Commands.UserRoles;
using WebStoreAPI.Commands.Users;

namespace WebStoreAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<CreateCityCommand, City>();
            CreateMap<UpdateCityCommand, City>();
            CreateMap<CreateCountryCommand, Country>();
            CreateMap<UpdateCountryCommand, Country>();
            CreateMap<CreateDeliveryCommand, Delivery>();
            CreateMap<UpdateDeliveryCommand, Delivery>();
            CreateMap<CreateManufacturerCommand, Manufacturer>();
            CreateMap<UpdateManufacturerCommand, Manufacturer>();
            CreateMap<CreateOrderItemsCommand, OrderItem>();
            CreateMap<UpdateOrderItemsCommand, OrderItem>();
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();
            CreateMap<CreatePaymentCommand, Payment>();
            CreateMap<UpdatePaymentCommand, Payment>();
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
            CreateMap<CreateTypeCommand, Type>();
            CreateMap<UpdateTypeCommand, Type>();
            CreateMap<CreateUserRoleCommand, UserRole>();
            CreateMap<UpdateUserRoleCommand, UserRole>();
        }
    }
}
