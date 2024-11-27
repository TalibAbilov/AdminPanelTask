using CoffeeTask.DAL;
using Microsoft.EntityFrameworkCore;

namespace CoffeeTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            });
            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
                 name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}");
            

            app.Run();
        }
    }
}
