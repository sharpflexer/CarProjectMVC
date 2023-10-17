using System.ComponentModel.DataAnnotations.Schema;

namespace CarProjectMVC.Models
{
    [Table("ModelColor")]
    public class CarModelCarColor
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public int ColorId { get; set; }
    }
}
