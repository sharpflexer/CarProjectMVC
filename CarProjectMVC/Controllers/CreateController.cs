using CarProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Controllers
{
    public class CreateController : Controller
    {
        ApplicationContext _context;

        public Car? Auto { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList BrandsSelect { get; private set; }

        public List<Brand> Brands { get; private set; } = new();

        public List<CarModel> Models { get; private set; } = new();

        public List<CarColor> Colors { get; private set; } = new();

        public CreateController(ApplicationContext context) 
        {
            _context = context;
            Brands = _context.Brands.Include(b => b.Models).AsNoTracking().ToList();
            Models = _context.Models.Include(m => m.Colors).AsNoTracking().ToList();
            Colors = _context.Colors.Include(c => c.Models).AsNoTracking().ToList();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpdateAsync(int id)
        {
            BrandsSelect = new(Brands, nameof(Brand.Id), nameof(Brand.Name));
            Auto = await _context.Cars.FindAsync(id);

            if (Auto == null) return NotFound();

            ViewData["BrandsSelect"] = BrandsSelect;
            ViewData["Auto"] = Auto;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            Auto = new Car()
            {
                Brand = _context.Brands.Single(brand => brand.Id == int.Parse(HttpContext.Request.Form["BrandId"])),
                Model = _context.Models.Single(model => model.Id == int.Parse(HttpContext.Request.Form["ModelId"])),
                Color = _context.Colors.Single(color => color.Id == int.Parse(HttpContext.Request.Form["ColorId"])),
            };
            _context.Cars.Add(Auto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Read");
        }
        public async Task<IActionResult> UpdateAsync()
        {
            Auto.Brand = _context.Brands.Single(brand => brand.Id == int.Parse(HttpContext.Request.Form["BrandId"]));
            Auto.Model = _context.Models.Single(model => model.Id == int.Parse(HttpContext.Request.Form["ModelId"]));
            Auto.Color = _context.Colors.Single(color => color.Id == int.Parse(HttpContext.Request.Form["ColorId"]));

            _context.Cars.Update(Auto!);
            await _context.SaveChangesAsync();
            return View("Index");
        }
        public JsonResult GetBrands()
        {
            return new(Brands);
        }
        public JsonResult GetModels(int id)
        {
            return new(Brands.Single(b => b.Id.Equals(id)).Models);
        }
        public JsonResult GetColors(int id)
        {
            return new(Models.Single(m => m.Id.Equals(id)).Colors);
        }
    }
}
