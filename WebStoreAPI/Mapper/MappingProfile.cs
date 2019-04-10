using System;
using AutoMapper;
using CommandAndQuerySeparation.Commands.Cities;
using CommandAndQuerySeparation.Commands.Countries;
using CommandAndQuerySeparation.Commands.Deliveries;
using CommandAndQuerySeparation.Commands.Manufacturers;
using CommandAndQuerySeparation.Commands.OrderItems;
using CommandAndQuerySeparation.Commands.Orders;
using CommandAndQuerySeparation.Commands.Payments;
using CommandAndQuerySeparation.Commands.Products;
using CommandAndQuerySeparation.Commands.Roles;
using CommandAndQuerySeparation.Commands.Types;
using CommandAndQuerySeparation.Commands.UserRoles;
using CommandAndQuerySeparation.Commands.Users;
using CommandAndQuerySeparation.Queries.Cities;
using CommandAndQuerySeparation.Queries.Countries;
using CommandAndQuerySeparation.Queries.Deliveries;
using CommandAndQuerySeparation.Queries.Manufacturers;
using CommandAndQuerySeparation.Queries.OrderItems;
using CommandAndQuerySeparation.Queries.Orders;
using CommandAndQuerySeparation.Queries.Payments;
using CommandAndQuerySeparation.Queries.Products;
using CommandAndQuerySeparation.Queries.Roles;
using CommandAndQuerySeparation.Queries.Types;
using CommandAndQuerySeparation.Queries.UserRoles;
using CommandAndQuerySeparation.Queries.Users;
using DataLibrary.Entities;
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

            CreateMap<CreateUserCommand, User>();
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
            CreateMap<CreateOrderCommand, Order>();
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

            CreateMap<GetAllCitiesQuery, City>();
            CreateMap<GetCityByIdQuery, City>();
            CreateMap<GetAllCountriesQuery, Country>();
            CreateMap<GetCountryByIdQuery, Country>();
            CreateMap<GetAllDeliveriesQuery, Delivery>();
            CreateMap<GetDeliveryByIdQuery, Delivery>();
            CreateMap<GetAllManufacturersQuery, Manufacturer>();
            CreateMap<GetManufacturerByIdQuery, Manufacturer>();
            CreateMap<GetAllOrderItemsQuery, OrderItem>();
            CreateMap<GetOrderItemsByIdQuery, OrderItem>();
            CreateMap<GetAllOrdersQuery, Order>();
            CreateMap<GetOrderByIdQuery, Order>();
            CreateMap<GetAllPaymentsQuery, Payment>();
            CreateMap<GetPaymentByIdQuery, Payment>();
            CreateMap<GetAllProductsQuery, Product>();
            CreateMap<GetProductByIdQuery, Product>();
            CreateMap<GetAllRolesQuery, Role>();
            CreateMap<GetRoleByIdQuery, Role>();
            CreateMap<GetAllTypesQuery, Type>();
            CreateMap<GetTypeByIdQuery, Type>();
            CreateMap<GetAllUserRolesQuery, UserRole>();
            CreateMap<GetUserRoleByIdQuery, UserRole>();
            CreateMap<GetAllUsersQuery, User>();
            CreateMap<GetUserByIdQuery, User>();           
        }
    }
}
