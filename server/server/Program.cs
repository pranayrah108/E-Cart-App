using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.Helper;
using server.Interface.Repository;
using server.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// 1️⃣ Configure SQL Server DbContext
builder.Services.AddDbContext<DataContex>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// 2️⃣ Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3️⃣ Configure JWT authentication
var key = Encoding.UTF8.GetBytes(configuration["JwtKey:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = configuration["JwtKey:Issuer"],
        ValidateAudience = true,
        ValidAudience = configuration["JwtKey:Audience"],
        RequireExpirationTime = true,
        ValidateLifetime = true
    };
});

// 4️⃣ Add DI for repositories and helpers
builder.Services.AddScoped<IJwtHelper, JwtHelper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// 5️⃣ Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 6️⃣ HTTPS, Authentication, Authorization
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// 7️⃣ Map controllers
app.MapControllers();

app.Run();
