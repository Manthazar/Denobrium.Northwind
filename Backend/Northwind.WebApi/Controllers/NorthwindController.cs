using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebApi.Controllers
{
    public abstract class NorthwindController : Controller
    {
        public NorthwindController (IServiceProvider services)
        {
            Mapper = services.GetRequiredService<IMapper>();
        }

        protected IMapper Mapper { get; }

    }
}
