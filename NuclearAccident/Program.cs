using AspNetCoreRateLimit;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Implementation;
using NuclearAccident.Src.Services.Interfaces;
using NuclearAccident.Src.UI.Controllers.Handler;
using NuclearAccident.Src.UI.Controllers.RouteConstraint;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("localSwagger",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5280/").AllowAnyMethod().AllowAnyHeader();
                      });
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

// Ajouter AspNetCoreRateLimit
builder.Services.AddRateLimiter(_ => _.AddSlidingWindowLimiter(policyName: "sliding", options =>
{
    options.PermitLimit = 15;
    options.Window = TimeSpan.FromSeconds(10);
    options.SegmentsPerWindow = 10;
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    options.QueueLimit = 5;
}));

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddInMemoryRateLimiting();

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
builder.Services.AddScoped<IAccidentService, AccidentServiceImpl>();
builder.Services.AddScoped<IStatistiqueService, StatistiquesImpl>();


// database connexion build the context

builder.Services.AddDbContext<NuclearAccidentContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

var app = builder.Build();
app.UseMiddleware<AccidentHandler>();
app.UseRateLimiter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("localSwagger");

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers().RequireRateLimiting("sliding");

app.Run();
