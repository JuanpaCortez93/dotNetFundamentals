using _004_Example5_Complete.DTOs.Students;
using _004_Example5_Complete.DTOs.Teachers;
using _004_Example5_Complete.FormatValidators.Students;
using _004_Example5_Complete.FormatValidators.Teachers;
using _004_Example5_Complete.MappingProfiles;
using _004_Example5_Complete.Models;
using _004_Example5_Complete.Repositories;
using _004_Example5_Complete.SchoolDbContext;
using _004_Example5_Complete.Services.Common;
using _004_Example5_Complete.Services.Students;
using _004_Example5_Complete.Services.Teachers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


    // ADD ENTITY FRAMEWORK - DBCONTEXT
    builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

    // VALIDATORS
    builder.Services.AddScoped<IValidator<StudentsPostDTO>, StudentsPostValidator>();
    builder.Services.AddScoped<IValidator<StudentsPutDTO>, StudentsPutValidator>();
    builder.Services.AddScoped<IValidator<TeachersPostDTO>, TeachersPostValidator>();
    builder.Services.AddScoped<IValidator<TeachersPutDTO>, TeachersPutValidator>();

    // SERVICES
    builder.Services.AddKeyedScoped<ICommonService<StudentsGetDTO, StudentsPostDTO, StudentsPutDTO>, StudentsService>("StudentsServices");
    builder.Services.AddKeyedScoped<ICommonService<TeachersGetDTO, TeachersPostDTO, TeachersPutDTO>, TeachersService>("TeachersServices");

    //REPOSITORY
    builder.Services.AddScoped<IRepository<Students>, StudentsRepository>();
    builder.Services.AddScoped<IRepository<Teachers>, TeachersRepository>();

    //MAPPING
    builder.Services.AddAutoMapper(typeof(StudentsMappingProfile));
    builder.Services.AddAutoMapper(typeof(TeachersMappingProfile));

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
