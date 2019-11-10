using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityApp.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage ="You must provide Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide Description")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
