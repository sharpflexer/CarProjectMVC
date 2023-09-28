using Microsoft.EntityFrameworkCore;

namespace CarProjectMVC.Models
{
    public class CarColor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CarModel> Models { get; set; }

    }
}