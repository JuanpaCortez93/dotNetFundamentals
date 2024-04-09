using _004_Example4_Refactorizacion.DatabaseContext;
using _004_Example4_Refactorizacion.DTOs.Clients;
using _004_Example4_Refactorizacion.DTOs.Products;
using _004_Example4_Refactorizacion.Services.Clients;
using _004_Example4_Refactorizacion.Services.Common;
using _004_Example4_Refactorizacion.Services.Orders;
using _004_Example4_Refactorizacion.Services.Products;
using _004_Example4_Refactorizacion.Validators.Clients;
using _004_Example4_Refactorizacion.Validators.Products;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    // Services
    builder.Services.AddKeyedScoped<ICommonService<ClientsGetDTO, ClientsPostDTO, ClientsPutDTO>, ClientsService>("ClientsService");
    builder.Services.AddKeyedScoped<ICommonService<ProductsGetDTO, ProductsPostDTO, ProductsPutDTO>, ProductsService>("ProductsService");
    builder.Services.AddKeyedScoped<IOrdersService, OrdersService>("OrdersService");

    // EF Core DbContext
    builder.Services.AddDbContext<EShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

    // Validators for clients
    builder.Services.AddScoped<IValidator<ClientsPostDTO>, ClientsPostValidator>();
    builder.Services.AddScoped<IValidator<ClientsPutDTO>, ClientsPutValidator>();

    // Validators for products
    builder.Services.AddScoped<IValidator<ProductsPostDTO>, ProductsPostValidator>();
    builder.Services.AddScoped<IValidator<ProductsPutDTO>, ProductsPutValidator>();



builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
