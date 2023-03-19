using Microsoft.EntityFrameworkCore;
using Services;
using Services.database;
using Services.database.repositories;
using Services.interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService,UserService>(); 
builder.Services.AddScoped<IEntityFrameworkDbContext, SQLliteDbContext>(); 
builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<SQLliteDbContext>(options => options.UseSqlite("Data Source=Todo.db"));
builder.Services.BuildServiceProvider().GetService<IEntityFrameworkDbContext>().InitializeDatabase();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
