using AutoMapper;
using Northwind.Api.Data;
using Northwind.Core.Models;

namespace Northwind.Api.Mapping
{
    internal class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierInfo>()
                 .ForMember(c => c.Id, opts => opts.MapFrom(s => s.Id))
                 .ForMember(c => c.CompanyName, opts => opts.MapFrom(s => s.CompanyName))
                 .ForMember(c => c.ContactName, opts => opts.MapFrom(s => s.ContactName))
                 .ForMember(c => c.ContactTitle, opts => opts.MapFrom(s => s.ContactTitle))
                 .ForMember(c => c.Phone, opts => opts.MapFrom(s => s.Phone))
                 .ForMember(c => c.HomePage, opts => opts.MapFrom(s => s.HomePage))
                 .ForMember(c => c.Fax, opts => opts.MapFrom(s => s.Fax))
                 ;
        }
    }
}
