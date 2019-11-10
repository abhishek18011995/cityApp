
using System.ComponentModel.DataAnnotations;

namespace CityApp.Models
{
    public class PointOfInterestForUpdationDto
    {
        [Required(ErrorMessage ="You must provide Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
