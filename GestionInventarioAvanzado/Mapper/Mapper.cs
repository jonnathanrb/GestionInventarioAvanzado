using AutoMapper;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Models.DTO;

namespace GestionInventarioAvanzado.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // ProductCategory Entity
            CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap();
            CreateMap<ProductCategory, CreateProductCategoryDTO>().ReverseMap();

            // Providers Entity
            CreateMap<Provider, ProviderDTO>().ReverseMap();
            CreateMap<Provider, CreateProviderDTO>().ReverseMap();

            // Products Entity
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();

            // Orders Entity
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            // CreateMap<CreateOrderDTO, Order>()
            // .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            // Order items
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDTO>().ReverseMap();
        }
    }
}
