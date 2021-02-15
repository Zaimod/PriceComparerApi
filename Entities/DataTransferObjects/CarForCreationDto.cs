using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CarForCreationDto
    {
        [Required(ErrorMessage = "Car brand is required")]
        [StringLength(60, ErrorMessage = "Car brand can't be longer than 60 characters")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Car model is required")]
        [StringLength(120, ErrorMessage = "Car model can't be longer than 120 characters")]
        public string Model { get; set; }
    }
}
