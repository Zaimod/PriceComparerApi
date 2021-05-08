using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string img { get; set; }
        public string description { get; set; }
        public string exclude { get; set; }
        public List<Catalog> catalog { get; set; } = new List<Catalog>();
    }
}
