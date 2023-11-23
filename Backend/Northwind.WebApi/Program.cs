using Northwind.Modules;
using Northwind.WebApi.ExceptionFilters;

var builder = WebApplication.CreateBuilder(args);
var sqlConnectionString = builder.Configuration["Northwind:SqlConnectionString"];

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ParameterExceptionFilter>();
});
builder.Services.AddRepositories(sqlConnectionString);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
