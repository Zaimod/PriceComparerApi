using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserApplication
{
    public interface IParser
    {
        Task<List<CatalogForCreationDto>> Run(string searchQuery);
    }
}
