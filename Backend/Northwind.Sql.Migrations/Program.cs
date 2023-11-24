using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Northwind.Core.Repositories;

namespace Northwind.Sql.Migrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddDbContext<NorthwindContext>(
                                options => options.UseSqlServer("Server=localhost;Database=Northwind;Trusted_Connection=True;",
                                            sqlServerOptions => sqlServerOptions.MigrationsAssembly(typeof(Program).Assembly.GetName().ToString())));
            });        
    }
}
