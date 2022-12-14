using MasterChef.Application.Interfaces;
using MasterChef.Application.Service;
using MasterChef.Domain.Contracts;
using MasterChef.Infrastructure;
using MasterChef.Persistence.Context;
using MasterChef.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connection = @"";
builder.Services.AddDbContext<DataContext>
    (o => o.UseSqlServer(connection));

builder.Services.AddTransient<IReceitaReader, ReceitaRssClient>();
builder.Services.AddTransient<IReceitaService, ReceitaService>();
builder.Services.AddTransient<IReceitaRepository, ReceitaRepository>();


builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("SetupApi"));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
