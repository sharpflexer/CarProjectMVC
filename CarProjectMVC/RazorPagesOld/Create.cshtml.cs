using CarProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace CarProject.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Car Auto { get; set; } = new();
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList BrandsSelect { get; private set; }
        public List<Brand> Brands { get; private set; } = new();
        public List<CarModel> Models { get; private set; } = new();
        public List<CarColor> Colors { get; private set; } = new();
        public CreateModel(ApplicationContext db)
        {
            context = db;
            Brands = context.Brands.Include(b => b.Models).AsNoTracking().ToList();
            Models = context.Models.Include(m => m.Colors).AsNoTracking().ToList();
            Colors = context.Colors.Include(c => c.Models).AsNoTracking().ToList();
        }
        public void OnGet()
        {
            BrandsSelect = new(Brands, nameof(Brand.Id), nameof(Brand.Name));
        }
        public async Task<IActionResult> OnPostAsync(int brandId, int modelId, int colorId)
        {
            Auto = new Car()
            {
                Brand = context.Brands.Single(brand => brand.Id == brandId),
                Model = context.Models.Single(model => model.Id == modelId),
                Color = context.Colors.Single(color => color.Id == colorId),
            };
            context.Cars.Add(Auto);
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