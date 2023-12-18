using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with MariaDB configuration
builder.Services.AddDbContext<AppContext>(options =>
   options.UseMySql(builder.Configuration.GetConnectionString("AppContext"), 
       new MariaDbServerVersion(new Version(10, 5)))); // Specify your MariaDB version here

// Add Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<AppContext>()
               .AddDefaultTokenProviders();

// Configure JWT Authentication
var jwtSection = builder.Configuration.GetSection("JWT");
var jwtKey = jwtSection["SecretKey"];

if (string.IsNullOrEmpty(jwtKey))
{
   throw new ArgumentException("JWT SecretKey cannot be null or empty.");
}

var jwtKeyBytes = Encoding.ASCII.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
   options.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuerSigningKey = true,
       IssuerSigningKey = new SymmetricSecurityKey(jwtKeyBytes),
       ValidateIssuer = false,
       ValidateAudience = false,
       RequireExpirationTime = false,
       ValidateLifetime = true
   };
});

// Add services to the container.
builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowSpecificOrigin",
       builder => builder.WithOrigins("https://localhost:3000", "https://localhost:5173", "http://localhost:5173") // Replace with your server URL
                         .AllowAnyHeader()
                         .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
