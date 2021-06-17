using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("FavouriteItem")]
    public class FavouriteItem
    {
        public int id { get; set; }
        public int catalogId { get; set; }
        public Catalog catalog { get; set; }
        public string userNameId { get; set; }
    }
}
