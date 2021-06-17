using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Catalog")]
    public class Catalog
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double NewPrice { get; set; }
        public string Url { get; set; }
        public bool FreeDelivery { get; set; }
        public bool Discount { get; set; }
        public int NumbReviews { get; set; }
        public DateTime LastModified { get; set; }
        public Store stores { get; set; }
        public int storeId { get; set; }
        public Category categories { get; set; }
        public int categoryId { get; set; }
        public int productId { get; set; }
        public Product products { get; set; }
        public List<FavouriteItem> FavouriteItems { get; set; } = new List<FavouriteItem>();
    }
}
