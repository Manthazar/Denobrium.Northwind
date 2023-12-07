using AutoMapper;
using Northwind.Api.Data;
using Northwind.Core.Models;

namespace Northwind.Api.Mapping
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderInfo>()
                .ForMember(c => c.Id, opts => opts.MapFrom(s => s.Id))
                .ForMember(c => c.CustomerCode, opts => opts.MapFrom(s => s.CustomerCode))
                .ForMember(c => c.EmployeeId, opts => opts.MapFrom(s => s.EmployeeId))
                .ForMember(c => c.OrderDate, opts => opts.MapFrom(s => s.OrderDate))
                .ForMember(c => c.RequiredDate, opts => opts.MapFrom(s => s.RequiredDate))
                .ForMember(c => c.ShippedDate, opts => opts.MapFrom(s => s.ShippedDate))
                .ForMember(c => c.ShipCountry, opts => opts.MapFrom(s => s.ShipCountry))
                .ForMember(c => c.IsInternationalShipment, opts => opts.Ignore());
                ;
        }
    }
}
