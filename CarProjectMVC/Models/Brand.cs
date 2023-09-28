using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CarModel> Models { get; set; }
    }
}