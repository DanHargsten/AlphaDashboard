using Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\EC Webbutveckling\5. ASP.NET\AlphaDashboard\Data\Database\local_db.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True"));

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
