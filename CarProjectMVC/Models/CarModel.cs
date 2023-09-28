using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CarColor> Colors { get; set; }

    }
}