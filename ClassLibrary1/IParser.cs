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
        /// <summary>
        /// Runs the specified search query.
        /// </summary>
        /// <param name="searchQuery">The search query.</param>
        /// <returns></returns>
        Task<List<CatalogForCreationDto>> Run(string searchQuery);
    }
}
