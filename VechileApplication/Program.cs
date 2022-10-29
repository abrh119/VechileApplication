using Microsoft.EntityFrameworkCore;
using VechileApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Inject DbContext
builder.Services.AddDbContext<vehicleDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("Development")));

builder.Services.AddCors(p => p.AddPolicy("corsapp", corsBuilder =>
{
    corsBuilder.WithOrigins(builder.Configuration["CorsAllowedHosts:FrontEndDevelopmentHost"], builder.Configuration["CorsAllowedHosts:FrontEndProductionHost"], builder.Configuration["CorsAllowedHosts:FrontEndDevelopmentAdminHost"]).AllowAnyMethod().AllowAnyHeader();
}));



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



