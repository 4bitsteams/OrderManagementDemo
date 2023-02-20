using AutoMapper;
using OrderManagement.Entity.Models;
using OrderManagementViewModel.ViewModels.SalesOrder;

namespace OrderManagement.Mapping
{
    public class SetupMapperProfile : Profile
    {
        public SetupMapperProfile()
        {
            CreateMap<OrderViewModel, Order>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Order, OrderDetailViewModel>().ReverseMap();
            CreateMap<OrderCreateViewModel, Order>().ReverseMap();
            CreateMap<OrderEditViewModel, Order>().ReverseMap();
            CreateMap<OrderEditViewModel, Order>().ReverseMap();

        }

    }
}
