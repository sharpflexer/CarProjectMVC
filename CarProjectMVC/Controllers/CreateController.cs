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

        public async Task<IActionResult> OnPostAsync(int brandId, int modelId, int colorId)
        {
            Auto.Brand = _context.Brands.Single(brand => brand.Id == brandId);
            Auto.Model = _context.Models.Single(model => model.Id == modelId);
            Auto.Color = _context.Colors.Single(color => color.Id == colorId);

            _context.Cars.Update(Auto!);
            await _context.SaveChangesAsync();
            return View("Index");
        }


        //public async Task<Microsoft.AspNetCore.Mvc.JsonResult> OnGetModelsById(int id)
        //{
        //    return new(Brands.Single(b => b.Id.Equals(id)).Models);
        //}
        //public async Task<Microsoft.AspNetCore.Mvc.JsonResult> OnGetColorsById(int id)
        //{
        //    var colors = Models.Single(m => m.Id.Equals(id)).Colors;
        //    return new(colors);
        //}

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
