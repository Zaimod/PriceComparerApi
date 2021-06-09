using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IParserManager
    {
        /// <summary>
        /// Checks the price.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<bool> CheckPrice(string url);
    }
}
