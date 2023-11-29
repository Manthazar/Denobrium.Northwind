using AutoMapper;
using Northwind.Api.Data.Data;
using Northwind.Core.Models;

namespace Northwind.Api.Data.Mapping
{
    internal class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerData>();
            CreateMap<Customer, CustomerInfo>();
        }
    }
}
