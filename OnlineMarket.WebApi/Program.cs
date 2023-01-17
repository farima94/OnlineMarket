using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using OnlineMarket.Application.Categories.Queries;
using OnlineMarket.Domain.DomainServices;
using OnlineMarket.Domain.Interfaces;
using OnlineMarket.Infrastructure.Common;
using OnlineMarket.Infrastructure.Persistence.SqlServer;
using OnlineMarket.WebApi.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var cn = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationDbContext>(p =>
    p.UseSqlServer(cn));


builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddMediatR(typeof(GetAllCategoryListHandler));
builder.Services.AddTransient<ICategoryDomainService, CategoryDomainService>();
builder.Services.AddScoped<IFileService, FileService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ApplicationExceptionHandler>();

var physicalPath = app.Environment.ContentRootPath;
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider($"{physicalPath}Image"),
    RequestPath = new PathString("/images")
});


app.UseAuthorization();

app.MapControllers();

app.Run();