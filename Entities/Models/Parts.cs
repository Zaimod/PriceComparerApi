using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("parts")]
    public class Parts
    {
        [Column("PartsId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public int Quantity { get; set; }
        public Guid CarsId { get; set; }
        public Cars Cars { get; set; }
        public Guid CategoryId { get; set; }
        public Category Categories { get; set; }
        public Guid SuppliersId { get; set; }
        public Suppliers Suppliers { get; set; }

    }
}
