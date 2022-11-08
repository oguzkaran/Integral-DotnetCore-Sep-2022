using Integral.CRM.Data.DAL;
using Integral.CRM.Data.Repository;

using Integral.CRM.Data.Service;
using IntegralWebServiceApplication.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

//Add dependency injections
builder.Services.AddServiceDependencies();

builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer("connection string"));

builder.Services.Configure<IdentityOptions>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireUppercase = false;
    o.Password.RequiredLength = 6;

    o.Lockout.MaxFailedAccessAttempts = 3;
    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(10);

    o.User.AllowedUserNameCharacters = "";
    o.User.RequireUniqueEmail = true;

    o.SignIn.RequireConfirmedEmail = true;
    o.SignIn.RequireConfirmedPhoneNumber = false;

});

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

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
