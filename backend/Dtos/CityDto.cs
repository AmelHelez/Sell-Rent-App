using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos
{
    public class CityDto
    {
        public int ID { get; set; }

        [Required (ErrorMessage = "Name is a mandatory field.")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Numerics are not allowed.")]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
