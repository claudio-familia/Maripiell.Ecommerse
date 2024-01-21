using Maripiell.Common.Common.Middlewares;
using Maripiell.Services.AuthAPI.DataAccess;
using Maripiell.Services.AuthAPI.DataAccess.Configuration;
using Maripiell.Services.AuthAPI.Domain.Models;
using Maripiell.Services.AuthAPI.Services;
using Maripiell.Services.AuthAPI.Services.Contracts;
using Maripiell.Services.AuthAPI.Services.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("Default") ?? "");
});
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();
builder.Services.AddRespositories();
builder.Services.AddSingleton(MapperConfig.RegisterMaps().CreateMapper());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuthService, AuthService>();


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

app.UseMiddleware<ExceptionMiddleware>("AuthAPI");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
