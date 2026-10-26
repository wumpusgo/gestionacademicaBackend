using System.Text;
using gestionAcademica.Security;
using gestionAcademica.Security.Data;
using gestionAcademica.Security.Models;
using gestionAcademica.Services;
using gestionAcademica.Services.Security;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder
    .Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        // Identity options
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"])
            ),
        };
    });

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProgramaAcademicoService, ProgramaAcademicoService>();
builder.Services.AddScoped<IClaseService, ClaseService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<SecurityDataService>();
builder.Services.AddScoped<ModelDataService>();
builder.Services.AddControllers();
builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        }
    );
});

var app = builder.Build();
app.UseCors("AllowAngularApp");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var securityDataService = services.GetRequiredService<SecurityDataService>();
    var modelDataService = services.GetRequiredService<ModelDataService>();
    DbInitializer
        .SeedApplicationDataAsync(context, securityDataService, modelDataService)
        .GetAwaiter()
        .GetResult();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
