using AutoMapper;
using Northwind.Api.Data;
using Northwind.Core.Models;

namespace Northwind.Api.Mapping
{
    internal sealed class ProductProfile : Profile
    {
        public ProductProfile()
        {
                CreateMap<Product, ProductInfo>()
                    .ForMember(c => c.Id, opts => opts.MapFrom(s => s.Id))
                    .ForMember(c => c.Name, opts => opts.MapFrom(s => s.ProductName))
                    .ForMember(c => c.IsDiscontinued, opts => opts.MapFrom(s => s.IsDiscontinued))
                    .ForMember(c => c.SupplierCompanyName, opts => opts.MapFrom(s => s.Supplier!.CompanyName))
                    .ForMember(c => c.CategoryName, opts => opts.MapFrom(s => s.Category!.CategoryName))
                    .ForMember(c => c.UnitsOnOrder, opts => opts.MapFrom(s => s.UnitsOnOrder))
                    .ForMember(c => c.QuanityPerUnit, opts => opts.MapFrom(s => s.QuantityPerUnit))
                    .ForMember(c => c.UnitsInStock, opts => opts.MapFrom(s => s.UnitsInStock))
                    ;
        }
    }
}
