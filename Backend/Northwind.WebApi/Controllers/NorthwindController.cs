using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebApi.Controllers
{
    public abstract class NorthwindController : Controller
    {
        public NorthwindController (IServiceProvider services)
        {
            Mapper = services.GetRequiredService<IMapper>();
            Services = services;
        }

        protected IMapper Mapper { get; }

        protected IServiceProvider Services { get; }

    }
}
