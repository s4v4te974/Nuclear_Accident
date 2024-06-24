using BrokenArrowApp.Src.BrokenArrowApp.Data;
using BrokenArrowApp.Src.BrokenArrowApp.Services.Implementation;
using BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces;
using BrokenArrowApp.Src.BrokenArrowApp.UI.Controllers.Handler;
using BrokenArrowApp.Src.BrokenArrowApp.UI.Controllers.RouteConstraint;
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

// add contsraint
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("AvailableYear", typeof(AvailableYearRouteConstraint));

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// add services
builder.Services.AddScoped<AutoMapper.Mapper>();
builder.Services.AddScoped<IVehiculeService, VehiculeServiceImpl>();
builder.Services.AddScoped<ILocationService, LocationServiceImpl>();
builder.Services.AddScoped<IWeaponService, WeaponServiceImpl>();
builder.Services.AddScoped<IBrokenArrowService, BrokenArrowServiceImpl>();


// database connexion build the context
builder.Services.AddDbContext<BrokenArrowContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyDatabase")));

var app = builder.Build();
app.UseMiddleware<BrokenArrowHandler>();

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
