using Microsoft.EntityFrameworkCore;
using SignalIrBasicChat.Models;
using SignalIrBasicChat.Services;

var builder = WebApplication.CreateBuilder(args);
// Configurar opciones de DbContext
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChatApplicationContext>( options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Development"));
});

builder.Services.AddScoped<IUsers, UserServices>();


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
