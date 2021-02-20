using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class SupplierForCreationDto
    {
        [Required(ErrorMessage = "Supplier name is required")]
        [StringLength(60, ErrorMessage = "Supplier name can't be longer than 60 characters")]
        public string Name { get; set; }

        public string Country { get; set; }


    }
}
