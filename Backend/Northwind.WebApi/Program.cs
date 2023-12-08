using Northwind.Api;
using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Core.Configuration;
using Northwind.Modules;
using Northwind.WebApi;
using Northwind.WebApi.ExceptionFilters;

var builder = WebApplication.CreateBuilder(args);
var sqlConnectionString = builder.Configuration["Northwind:SqlConnectionString"];
var configuration = new NorthwindApiConfiguration();

var services = builder.Services;

services.AddControllers(options =>
{
    options.Filters.Add<ParameterExceptionFilter>();
}).ConfigureJsonHandler(configuration);
    
services.AddNorthwindStoreConfiguration();
services.AddRepositories(sqlConnectionString);
services.AddApiServices();
services.AddDataModuleComponents();
services.AddSingletonMapper();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();


