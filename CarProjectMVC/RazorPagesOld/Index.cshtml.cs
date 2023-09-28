using CarProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarProject.Pages
{
    public class IndexModel : PageModel
    {
        public List<Car> Cars { get; set; } = new();
        public IndexModel()
        {
        }
    }
}
