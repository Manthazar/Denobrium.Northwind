using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Modules;
using Northwind.WebApi.ExceptionFilters;

var builder = WebApplication.CreateBuilder(args);
var sqlConnectionString = builder.Configuration["Northwind:SqlConnectionString"];

var services = builder.Services;

services.AddControllers(options =>
{
    options.Filters.Add<ParameterExceptionFilter>();
});

services.AddRepositories(sqlConnectionString);
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


