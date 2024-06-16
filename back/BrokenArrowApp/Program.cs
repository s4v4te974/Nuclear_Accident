using BrokenArrowApp.Controllers.Handler;
using BrokenArrowApp.Data;
using BrokenArrowApp.Service;
using BrokenArrowApp.Service.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("localSwagger",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5280/").AllowAnyMethod().AllowAnyHeader();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// add services
builder.Services.AddScoped<AutoMapper.Mapper>();
builder.Services.AddScoped<IVehiculeService, VehiculeServiceImpl>();
builder.Services.AddScoped<ICoordonateService, CoordonateServiceImpl>();
builder.Services.AddScoped<IWeaponService, WeaponServiceImpl>();


// database connexion build the context
builder.Services.AddDbContext<BrokenArrowContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyDatabase")));

var app = builder.Build();
app.UseMiddleware<ErrorHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("localSwagger");

app.UseAuthorization();

app.MapControllers();

app.Run();
