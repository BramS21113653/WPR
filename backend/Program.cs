// DEPLOYMENT program.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel (Web Server)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000); // Listen for HTTP on port 5000
    // serverOptions.ListenAnyIP(5001, listenOptions => // Listen for HTTPS on port 5001
    // {
    //     listenOptions.UseHttps(); // You can specify the certificate here for production
    // });
});

// Add DbContext with MariaDB configuration
builder.Services.AddDbContext<AppContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("AppContext"), 
    new MariaDbServerVersion(new Version(10, 5))));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<AppContext>()
        .AddDefaultTokenProviders();

// Register IUserService for dependency injection
builder.Services.AddScoped<IUserService, UserService>();

// Configure JWT Authentication
var jwtSection = builder.Configuration.GetSection("JWT");
builder.Services.Configure<AppSettings>(jwtSection); // Configure AppSettings with JWT section

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
        builder => builder.WithOrigins("http://accessibility.steenkamp.eu", "https://localhost:3000", "https://localhost:5173", "http://localhost:5173", "https://localhost:5174", "http://localhost:5174")
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





//
//
//
//
//
//
//
//
// HIERONDER VOOR NON DEPLOYMENT (NIET VERWIJDEREN)
//
//
//
//
//
//
//


// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using System;

// var builder = WebApplication.CreateBuilder(args);

// // Add DbContext with MariaDB configuration
// builder.Services.AddDbContext<AppContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("AppContext"), 
//     new MariaDbServerVersion(new Version(10, 5))));

// // // Add Identity
// // builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
// //     .AddEntityFrameworkStores<AppContext>()
// //     .AddDefaultTokenProviders();

// builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
//         .AddEntityFrameworkStores<AppContext>()
//         .AddDefaultTokenProviders();

// // Register IUserService for dependency injection
// builder.Services.AddScoped<IUserService, UserService>();

// // Configure JWT Authentication
// var jwtSection = builder.Configuration.GetSection("JWT");
// builder.Services.Configure<AppSettings>(jwtSection); // Configure AppSettings with JWT section

// var jwtKey = jwtSection["SecretKey"];
// if (string.IsNullOrEmpty(jwtKey))
// {
//     throw new ArgumentException("JWT SecretKey cannot be null or empty.");
// }
// var jwtKeyBytes = Encoding.ASCII.GetBytes(jwtKey);

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(jwtKeyBytes),
//         ValidateIssuer = false,
//         ValidateAudience = false,
//         RequireExpirationTime = false,
//         ValidateLifetime = true
//     };
// });

// // Add services to the container.
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowSpecificOrigin",
//         builder => builder.WithOrigins("https://localhost:3000", "https://localhost:5173", "http://localhost:5173", "https://localhost:5174", "http://localhost:5174")
//                           .AllowAnyHeader()
//                           .AllowAnyMethod());
// });
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// app.UseCors("AllowSpecificOrigin");
// app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();
// app.MapControllers();
// app.Run();
