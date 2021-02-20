using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("category")]
    public class Category
    {
        [Column("CategoryId")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Parts> Parts { get; set; } = new List<Parts>();
    }
}
