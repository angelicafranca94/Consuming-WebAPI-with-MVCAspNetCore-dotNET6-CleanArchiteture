using MasterChef.Application.Interfaces;
using MasterChef.Application.Service;
using MasterChef.Domain.Contracts;
using MasterChef.Persistence.Context;
using MasterChef.Persistence.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MasterChef.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(
    s => {
        s.SwaggerDoc("v1", new OpenApiInfo() { Title = "Master Chef API", Version = "V1" });
    });

builder.Services.AddControllers(config =>
{

    config.RespectBrowserAcceptHeader = true;
}).AddXmlDataContractSerializerFormatters();


builder.Services.AddCors(x => {
    x.AddPolicy("Default", b => {
        b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});



var connection = @"Server=PERSONAL;Database=MasterChefDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
builder.Services.AddDbContext<DataContext>
    (o => o.UseSqlServer(connection));


builder.Services.AddTransient<IReceitaReader, ReceitaRssClient>();
builder.Services.AddTransient<IReceitaService, ReceitaService>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<IReceitaRepository, ReceitaRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddMemoryCache();

builder.Services.Configure<RouteOptions>
                (options => options.LowercaseUrls = true);

var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Add("api-version", "v.1.0");
//    await next.Invoke();
//});


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Master Chef API"));


app.UseRouting();


app.UseCors("Default");

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();

