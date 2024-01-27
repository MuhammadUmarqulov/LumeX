using Lumex.Api.Extensions;
using Lumex.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// database configuration
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// services
builder.Services.AddCustomServices();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddSwaggerService();


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
