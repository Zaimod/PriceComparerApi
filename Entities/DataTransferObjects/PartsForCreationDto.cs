using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PartsForCreationDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public int Quantity { get; set; }
        public Guid CarsId { get; set; }

        public Guid CategoryId { get; set; }
        public Guid SuppliersId { get; set; }
    }
}
