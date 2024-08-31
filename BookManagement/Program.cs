using BookManagement.Exceptions;
using BookManagement.Models;
using BookManagement.Repositories;
using BookManagement.Repositories.Contracts;
using BookManagement.Services;
using BookManagement.Services.Contracts;
using Microsoft.EntityFrameworkCore;

//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();

// using this to get the connection with the database and create an instance of DbContext  
builder.Services.AddDbContext<BookDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyServer")));

// using this for dependency injection for the repository and the service interface
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
 
// using this for dependency injection for the exception handling
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

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

// using the exception handling middleware in the request pipeline
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
