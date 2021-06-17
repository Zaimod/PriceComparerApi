using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class FavouriteItemDto
    {
        public int id { get; set; }
        public int catalogId { get; set; }
        public CatalogDto catalog { get; set; }
        public string userNameId { get; set; }
    }
}
