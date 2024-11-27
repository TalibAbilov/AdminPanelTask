using CoffeeTask.DAL;
using CoffeeTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeTask.Areas.manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        AppDbContext context;
        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var categories= await context.Categories.Include(p=>p.products).ToListAsync();
            return View(categories);
        }
      
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) {
                return View();
            }
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) {
                return NotFound();
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category newCategory)
        {
            if (!ModelState.IsValid) {
                return View(newCategory);
            }
            var oldCategory = context.Categories.FirstOrDefault(c => c.Id == newCategory.Id);
            if (oldCategory == null)
            {
                return NotFound();
            }
            oldCategory.Name = newCategory.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
