using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WorkShiftPlanningService.Models;
using Microsoft.Extensions.Configuration;
using WorkShiftPlanningService.Models.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWorkShiftService();
builder.Services.AddStaffService();
builder.Services.AddRestaurantService();

builder.Services.AddDbContext<MainDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
