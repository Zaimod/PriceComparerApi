using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string img { get; set; }
        public string description { get; set; }
        public string exclude { get; set; }
        public int numbReviews { get; set; }
        public int categoryId { get; set; }
        public List<Catalog> catalog { get; set; } = new List<Catalog>();
    }
}
