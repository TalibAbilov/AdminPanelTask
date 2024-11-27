using CoffeeTask.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeTask.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext context;
        public HomeController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products=context.Products.ToList();
            return View(products);
        }
    }
}
