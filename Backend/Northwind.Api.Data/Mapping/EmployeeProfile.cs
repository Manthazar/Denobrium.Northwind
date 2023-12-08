using AutoMapper;
using Northwind.Api.Data;
using Northwind.Core.Models;

namespace Northwind.Api.Mapping
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeInfo>()
                 .ForMember(c => c.Id, opts => opts.MapFrom(s => s.Id))
                 .ForMember(c => c.LastName, opts => opts.MapFrom(s => s.LastName))
                 .ForMember(c => c.FirstName, opts => opts.MapFrom(s => s.FirstName))
                 .ForMember(c => c.Title, opts => opts.MapFrom(s => s.Title))
                 .ForMember(c => c.TitleOfCourtesy, opts => opts.MapFrom(s => s.TitleOfCourtesy))

                 .ForMember(c => c.ReportsToId, opts => opts.MapFrom(s => s.ReportsToId))
                 .ForMember(c => c.ReportsToName, opts => opts.MapFrom(s => s.ReportsTo!.GetFullName()))

                 .ForMember(c => c.Photo, opts => opts.MapFrom(s => s.Photo))
                 .ForMember(c => c.PhotoPath, opts => opts.MapFrom(s => s.PhotoPath))
                 ;
        }
    }
}
