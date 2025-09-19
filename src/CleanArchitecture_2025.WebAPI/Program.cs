using CleanArchitecture_2025.Infrastructure;
using CleanArchitecture_2025.Application;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.OData;
using CleanArchitecture_2025.WebAPI.Controller;
using CleanArchitecture_2025.WebAPI.Modules;
using CleanArchitecture_2025.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(); // open api kullanýlmasý içi cors eklenmeli
builder.Services.AddOpenApi();
builder.Services.AddControllers().AddOData(opt => 
        opt
        .Select()
        .Filter()
        .Count()
        .Expand()
        .OrderBy()
        .SetMaxTop(null)
        .AddRouteComponents("odata", AppODataController.GetEdmModel())
);
builder.Services.AddRateLimiter(x =>
x.AddFixedWindowLimiter("fixed", cfg =>
{
    cfg.QueueLimit = 100;
    cfg.Window = TimeSpan.FromSeconds(1);
    cfg.PermitLimit = 100;
    cfg.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
})); // ayný anda çok fazla istek gelirse engellemek için

builder.Services.AddExceptionHandler<ExceptionHandler>().AddProblemDetails();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapDefaultEndpoints();

app.UseCors(policy => policy
.AllowCredentials()
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed(t => true)); // open api kullanýlmasý içi cors eklenmeli

app.RegisterRoutes();

app.UseExceptionHandler();

app.MapControllers().RequireRateLimiting("fixed"); // yazýlan her controller için fixed rate limiter uygulanýr

app.Run();
