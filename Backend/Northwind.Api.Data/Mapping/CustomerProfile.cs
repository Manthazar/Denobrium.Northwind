﻿using AutoMapper;
using Northwind.Api.Data;
using Northwind.Core.Models;

namespace Northwind.Api.Mapping
{
    internal sealed class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDetail>()
                .ForMember(c => c.Id, opts => opts.MapFrom(s => s.Id))
                .ForMember(c => c.Code, opts => opts.MapFrom(s => s.Code))
                ;

            CreateMap<Customer, CustomerInfo>()
                .ForMember(c => c.CustomerId, opts => opts.MapFrom(s => s.Id))
                .ForMember(c => c.CustomerCode, opts => opts.MapFrom(s => s.Code))
                ;
        }
    }
}
