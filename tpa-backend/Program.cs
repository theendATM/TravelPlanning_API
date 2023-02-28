using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tpa_backend.Data;
using tpa_backend.Models;
using tpa_backend.Services;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7226/",
                                              "http://localhost:3000",
                                              "http://127.0.0.1:3000",
                                              "https://localhost:3000",
                                              "https://127.0.0.1:3000");
                          policy.AllowAnyHeader();
                          policy.AllowCredentials();
                          policy.WithExposedHeaders("*");
                          policy.AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITouristService, TouristService>();
builder.Services.AddScoped<IPlanService, PlanService>();

var app = builder.Build();
app.Run();
