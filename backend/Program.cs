using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<AppContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("AppContext") ?? throw new InvalidOperationException("Connection string 'AppContext' not found.")));

// Add DbContext with MariaDB configuration
builder.Services.AddDbContext<AppContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("AppContext"), 
        new MariaDbServerVersion(new Version(10, 5)))); // Specify your MariaDB version here


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppContext>()
                .AddDefaultTokenProviders();
builder.Services.AddAuthentication();

// Add services to the container.
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder => builder.WithOrigins("http://localhost:3000") // Vervang met je Vite server URL
                               .AllowAnyHeader()
                               .AllowAnyMethod());
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
