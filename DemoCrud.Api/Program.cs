using DemoCrud.Api.Contexts;
using DemoCrud.Api.Filter;
using DemoCrud.Api.Repositories;
using DemoCrud.Api.Validators;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DemoCrud.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
	options.Filters.Add(typeof(HttpGlobalExceptionFilter));
});
builder.Services.AddDbContext<DataContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DataConnection"), sqlOptions =>
	{
		sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
	})
);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductElasticRepository, ProductElasticRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<CarValidator>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddElasticsearch(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
