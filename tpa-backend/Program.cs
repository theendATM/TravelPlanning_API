using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using tpa_backend.Data;
using tpa_backend.Models;
using tpa_backend.Services;

[assembly: ApiController]
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
                          policy.AllowAnyHeader();
                      });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};

//builder.Services.AddIdentity<User, IdentityRole>()
//                .AddEntityFrameworkStores<AppDbContext>();

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Default Password settings.
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;
//});

/*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "MyAppCookie";
        options.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = context =>
            {
                // Your validation logic here
                return Task.CompletedTask;
            }
        };
    });*/

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITouristService, TouristService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<ILandmarkService, LandmarkService>();
builder.Services.AddScoped<ISelectInfoService , SelectInfoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.MapDefaultControllerRoute();
app.MapControllers();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.UseIdentity();
app.UseCors(MyAllowSpecificOrigins);

if (app.Environment.IsDevelopment())
{
    app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));
}

app.Run();
