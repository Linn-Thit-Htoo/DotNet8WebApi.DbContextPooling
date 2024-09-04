using DotNet8WebApi.DbContextPooling.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<AppDbContext>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    },
    poolSize: 100
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
