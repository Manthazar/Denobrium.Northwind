using AutoMapper;
using Northwind.Api.Data.Data;
using Northwind.Core.Models;

namespace Northwind.Api.Data.Mapping
{
    internal class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerData>()
                .ForMember(c => c.Id, opts => opts.MapFrom(s => s.Id));

            CreateMap<Customer, CustomerInfo>()
                .ForMember(c => c.CustomerId, opts => opts.MapFrom(s => s.Id));
        }
    }
}
