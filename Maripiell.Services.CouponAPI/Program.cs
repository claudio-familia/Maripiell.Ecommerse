using Maripiell.Services.CouponAPI.DataAccess;
using Maripiell.Services.CouponAPI.DataAccess.Configuration;
using Maripiell.Services.CouponAPI.Services.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CouponDBContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("Default") ?? "");
});

builder.Services.AddRespositories();

var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? [];

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

builder.Services.AddSingleton(MapperConfig.RegisterMaps().CreateMapper());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("myAppCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
