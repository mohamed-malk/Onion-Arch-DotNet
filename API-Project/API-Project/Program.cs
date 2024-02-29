using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;
using Presentation;
using Services.Abstraction.DataServices;
using Services.DataServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Add Services

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

var connection = builder.Configuration.GetConnectionString("mosCon");
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connection, b => b.MigrationsAssembly("Persistence")));

// Add Controllers 
builder.Services.AddControllers().AddApplicationPart(
    typeof(AssemblyReferneces).Assembly);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();