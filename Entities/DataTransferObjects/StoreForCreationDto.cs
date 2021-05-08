using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class StoreForCreationDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
