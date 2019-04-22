using System;
using AutoMapper;
using CQS.Commands.Cities;
using CQS.Commands.Countries;
using CQS.Commands.Deliveries;
using CQS.Commands.Manufacturers;
using CQS.Commands.OrderItems;
using CQS.Commands.Orders;
using CQS.Commands.Payments;
using CQS.Commands.Products;
using CQS.Commands.Roles;
using CQS.Commands.Types;
using CQS.Commands.UserRoles;
using CQS.Commands.Users;
using DataLibrary.Entities;
using Specification.Requests.Cities;
using Specification.Requests.Countries;
using Specification.Requests.Deliveries;
using Specification.Requests.Manufacturers;
using Specification.Requests.OrderItems;
using Specification.Requests.Orders;
using Specification.Requests.Payments;
using Specification.Requests.Products;
using Specification.Requests.Roles;
using Specification.Requests.Types;
using Specification.Requests.UserRoles;
using Specification.Requests.Users;
using WebStoreAPI.Response.Cities;
using WebStoreAPI.Response.Countries;
using WebStoreAPI.Response.Deliveries;
using WebStoreAPI.Response.Manufacturers;
using WebStoreAPI.Response.OrderItems;
using WebStoreAPI.Response.Orders;
using WebStoreAPI.Response.Payments;
using WebStoreAPI.Response.Products;
using WebStoreAPI.Response.Roles;
using WebStoreAPI.Response.Types;
using WebStoreAPI.Response.UserRoles;
using WebStoreAPI.Response.Users;
using Type = DataLibrary.Entities.Type;

namespace WebStoreAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(o => 1));

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(x => x.ModifiedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(o => 1));

            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.RegistrationTime, opt => opt.MapFrom(o => DateTime.Now));

            CreateMap<UpdateUserCommand, User>();
            CreateMap<CreateCityCommand, City>();
            CreateMap<UpdateCityCommand, City>();
            CreateMap<CreateCountryCommand, Country>();
            CreateMap<UpdateCountryCommand, Country>();
            CreateMap<CreateDeliveryCommand, Delivery>()
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(o => 1));

            CreateMap<UpdateDeliveryCommand, Delivery>()
                .ForMember(x => x.ModifiedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(o => 1));

            CreateMap<CreateManufacturerCommand, Manufacturer>();
            CreateMap<UpdateManufacturerCommand, Manufacturer>();
            CreateMap<CreateOrderItemsCommand, OrderItem>();
            CreateMap<UpdateOrderItemsCommand, OrderItem>();

            CreateMap<CreateOrderCommand, Order>()
                .ForMember(x => x.OrderTime, opt => opt.MapFrom(o => DateTime.Now));

            CreateMap<UpdateOrderCommand, Order>();
        
            CreateMap<CreatePaymentCommand, Payment>()
                .ForMember(x => x.CreatedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(o => 1));

            CreateMap<UpdatePaymentCommand, Payment>()
                .ForMember(x => x.ModifiedDateTime, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(o => 1));

            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
            CreateMap<CreateTypeCommand, Type>();
            CreateMap<UpdateTypeCommand, Type>();
            CreateMap<CreateUserRoleCommand, UserRole>();
            CreateMap<UpdateUserRoleCommand, UserRole>();

            CreateMap<CreateCityRequest, CreateCityResponse>();
            CreateMap<CreateCountryRequest, CreateCountryResponse>();
            CreateMap<CreateDeliveryRequest, CreateDeliveryResponse>();
            CreateMap<CreateManufacturerRequest, CreateManufacturerResponse>();
            CreateMap<CreateOrderItemsRequest, CreateOrderItemsResponse>();
            CreateMap<CreateOrderRequest, CreateOrderResponse>();
            CreateMap<CreatePaymentRequest, CreatePaymentResponse>();
            CreateMap<CreateProductRequest, CreateProductResponse>();
            CreateMap<CreateRoleRequest, CreateRoleResponse>();
            CreateMap<CreateTypeRequest, CreateTypeResponse>();
            CreateMap<CreateUserRolesRequest, CreateUserRolesResponse>();
            CreateMap<CreateUserRequest, CreateUserResponse>();
        }
    }
}
