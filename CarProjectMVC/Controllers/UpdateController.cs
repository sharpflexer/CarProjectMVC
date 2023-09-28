using CarProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Controllers
{
    public class UpdateController : Controller
    {
        ApplicationContext _context;
        [BindProperty]
        public Car? Auto { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList BrandsSelect { get; private set; }
        public List<Brand> Brands { get; private set; } = new();
        public List<CarModel> Models { get; private set; } = new();
        public List<CarColor> Colors { get; private set; } = new();
        public UpdateController(ApplicationContext context)
        {
            _context = context;
            Brands = _context.Brands.Include(b => b.Models).AsNoTracking().ToList();
            Models = _context.Models.Include(m => m.Colors).AsNoTracking().ToList();
            Colors = _context.Colors.Include(c => c.Models).AsNoTracking().ToList();
        }

       
    }
}
