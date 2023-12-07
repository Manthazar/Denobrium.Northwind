using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.WebApi.Controllers
{
    public abstract class NorthwindController : Controller
    {
        public NorthwindController (IServiceProvider services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
            Mapper = services.GetRequiredService<IMapper>();
        }

        protected IMapper Mapper { get; }

        protected IServiceProvider Services { get; }

    }
}
