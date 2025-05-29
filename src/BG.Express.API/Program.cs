using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BG.Express.API.Data;
using BG.Express.API.Services;
using BG.Express.API.Services.Implementations; 
using BG.Express.API.Data.Entity;
using Beymen.IT.Package.EntityFrameworkCore.Repositories;
using Beymen.IT.Package.EntityFrameworkCore;
using Beymen.IT.Package.ExceptionHandling;
using BG.Express.API.Helpers;
using BG.Express.API.Model;
using BG.Express.API.Settings;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// **Configuration**
var configuration = builder.Configuration;

// **Optiyol Service Settings**
var optiyolServiceSettings = builder.Configuration.GetSection("OptiyolServiceSettings").Get<OptiyolServiceSettings>();
builder.Services.AddSingleton(optiyolServiceSettings);

// **Services Configuration**
// Veritabanı bağlantısını yapılandırıyoruz.
builder.Services.AddDbContext<ExpressContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

// **Unit of Work Dependency Injection**
builder.Services.AddScoped<IUnitOfWork, ExpressUnitOfWork>();

builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IOptiyolService, OptiyolService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();



builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient("optiyolservice", c =>
{
  c.BaseAddress = new Uri(optiyolServiceSettings.ApiUrl);
  c.Timeout = TimeSpan.FromMilliseconds(optiyolServiceSettings.Timeout);
  c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", optiyolServiceSettings.Token);
});

// Sağlık kontrolleri
builder.Services.AddHealthChecks().AddCheck<HealthCheckService>("healthcheck");

// **JWT Authentication**
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
builder.Services.AddSingleton(appSettings);

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// **Authorization**
builder.Services.AddAuthorization();

// **Swagger Configuration**
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BG.Express.API",
        Version = "v1",
        Description = "BG Express API for Address Management"
    });

    // Swagger için JWT ayarları
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token in the text input below."
    };

    options.AddSecurityDefinition("Bearer", securityScheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// **Controllers**
builder.Services.AddControllers();

var app = builder.Build();

// **Middleware Configuration**
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "BG.Express.API v1");
        options.RoutePrefix = string.Empty; // Swagger UI ana sayfada görünsün
    });
}

app.UseSwagger(options =>
{
#if !DEBUG
    options.PreSerializeFilters.Add((document, request) =>
    {
        var openApiPaths = new OpenApiPaths();
        foreach (var (key, value) in document.Paths)
        {
            openApiPaths.Add($"/bg-express-api{key}", value);
        }
        document.Paths = openApiPaths;
    });
#endif
});

app.UseSwaggerUI(options =>
{
    var endpointUrl = "/swagger/v1/swagger.json";
#if !DEBUG
    endpointUrl = $"/bg-express-api{endpointUrl}";
#endif
    options.SwaggerEndpoint(endpointUrl, "Bg Express");
});

app.UseHttpsRedirection();
app.UseErrorWrappingMiddleware();

app.UseRouting();
app.UseAuthentication(); // JWT doğrulama için gerekli
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healthcheck");

app.Run();
