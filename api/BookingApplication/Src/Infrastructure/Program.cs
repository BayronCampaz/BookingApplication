using Application.Mappers;
using Application.Services;
using Application.Validators;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.RequestModels;
using Domain.Abstractions.Services;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;
using Web.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString));

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});


builder.Services.AddAutoMapper(cfg => cfg.AllowNullCollections = true, Assembly.GetAssembly(typeof(RestaurantProfile)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<ITableService, TableService>();

builder.Services.AddScoped<IValidator<RestaurantRequest>, RestaurantRequestValidator>();
builder.Services.AddScoped<IValidator<TableRequest>, TableRequestValidator>();
builder.Services.AddScoped<IValidator<BookingRequest>, BookingRequestValidator>();
builder.Services.AddScoped<IValidator<ClientRequest>, ClientRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
