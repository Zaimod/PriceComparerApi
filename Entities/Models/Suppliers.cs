using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("suppliers")]
    public class Suppliers
    {
        [Column("SupplierId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name of Supplier type is required")]
        [StringLength(60, ErrorMessage = "Name of Supplier can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country of Supplier type is required")]
        [StringLength(60, ErrorMessage = "Country of Supplier can't be longer than 60 characters")]
        public string Country { get; set; }

        public List<Cars> Cars { get; set; } = new List<Cars>();
        public List<Parts> Parts { get; set; } = new List<Parts>();
    }
}
