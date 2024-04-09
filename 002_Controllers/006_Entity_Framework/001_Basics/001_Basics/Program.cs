using _001_Basics;
using _001_Basics.DTOs;
using _001_Basics.Models;
using _001_Basics.Repository;
using _001_Basics.Services;
using _001_Basics.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Services
builder.Services.AddKeyedScoped<ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>, BeerService>("BeerService");

// Add DbContext
builder.Services.AddDbContext<BeerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

// Repository
builder.Services.AddScoped<IRepository<BeerModels>, BeerRepository>();

// Add Validators
builder.Services.AddScoped<IValidator<BeerInsertDTO>, BeerInsertValidator>();   
builder.Services.AddScoped<IValidator<BeerUpdateDTO>, BeerUpdateValidator>();

// Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

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
