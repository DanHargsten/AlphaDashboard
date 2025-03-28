using Business.Services;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options
    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\EC Webbutveckling\5. ASP.NET\AlphaDashboard\Data\Database\local_db.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True"))
    .AddScoped<IProjectRepository, ProjectRepository>()
    .AddScoped<ProjectService>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=Projects}/{id?}")
    .WithStaticAssets();

app.Run();
