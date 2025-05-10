using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using LibraryManager.API.Filters;
using LibraryManager.Infrastructure.Context;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using LibraryManager.Infrastructure.Repositories;
using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.Services;
using LibraryManager.Infrastructure.Persistence.UoW;
using LibraryManager.Infrastructure.AuthServices;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("LibraryManagementCS");
builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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
