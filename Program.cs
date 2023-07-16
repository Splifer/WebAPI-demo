using Microsoft.EntityFrameworkCore;
using WebAPI_demo.Models.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DbprojectContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("connectString"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.DefaultModelsExpandDepth(-1));
}

app.UseAuthorization();

app.MapControllers();

app.Run();