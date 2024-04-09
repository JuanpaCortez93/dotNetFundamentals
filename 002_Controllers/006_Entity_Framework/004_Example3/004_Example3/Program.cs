using _004_Example3.Context;
using _004_Example3.DTOs.Patients;
using _004_Example3.Models;
using _004_Example3.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Entity Framework -> AddDbContext
builder.Services.AddDbContext<PatientsDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

//Validators
builder.Services.AddScoped<IValidator<PatientsPostDTO>, PatientsPostValidator>();
builder.Services.AddScoped<IValidator<PatientsPutDTO>, PatientsPutValidator>();

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
