using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserApplication
{
    public interface IComponent
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<String> GetName(HtmlAgilityPack.HtmlNode item);

        /// <summary>
        /// Gets the new price.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<double> GetNewPrice(HtmlAgilityPack.HtmlNode item);

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<double> GetPrice(HtmlAgilityPack.HtmlNode item);

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<String> GetUrl(HtmlAgilityPack.HtmlNode item);

        /// <summary>
        /// Determines whether [is free delivery] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> IsFreeDelivery(HtmlAgilityPack.HtmlNode item);

        /// <summary>
        /// Determines whether the specified item is discount.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> IsDiscount(HtmlAgilityPack.HtmlNode item);
    }
}
