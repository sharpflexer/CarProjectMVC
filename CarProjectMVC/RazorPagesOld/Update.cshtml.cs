using CarProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace CarProject.Pages
{
    [IgnoreAntiforgeryToken]
    public class UpdateModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Car? Auto { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList BrandsSelect { get; private set; }
        public List<Brand> Brands { get; private set; } = new();
        public List<CarModel> Models { get; private set; } = new();
        public List<CarColor> Colors { get; private set; } = new();
        public UpdateModel(ApplicationContext db)
        {
            context = db;
            Brands = context.Brands.Include(b => b.Models).AsNoTracking().ToList();
            Models = context.Models.Include(m => m.Colors).AsNoTracking().ToList();
            Colors = context.Colors.Include(c => c.Models).AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            BrandsSelect = new(Brands, nameof(Brand.Id), nameof(Brand.Name));
            Auto = await context.Cars.FindAsync(id);

            if (Auto == null) return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int brandId, int modelId, int colorId)
        {
            Auto.Brand = context.Brands.Single(brand => brand.Id == brandId);
            Auto.Model = context.Models.Single(model => model.Id == modelId);
            Auto.Color = context.Colors.Single(color => color.Id == colorId);        

            context.Cars.Update(Auto!);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }


        public async Task<Microsoft.AspNetCore.Mvc.JsonResult> OnGetModelsById(int id)
        {
            return new(Brands.Single(b => b.Id.Equals(id)).Models);
        }
        public async Task<Microsoft.AspNetCore.Mvc.JsonResult> OnGetColorsById(int id)
        {
            var colors = Models.Single(m => m.Id.Equals(id)).Colors;
            return new(colors);
        }
    }
}