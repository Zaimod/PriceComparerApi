using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserApplication
{
    public interface IComponent
    {
        Task<String> GetName(HtmlAgilityPack.HtmlNode item);
        Task<double> GetNewPrice(HtmlAgilityPack.HtmlNode item);
        Task<double> GetPrice(HtmlAgilityPack.HtmlNode item);
        Task<String> GetUrl(HtmlAgilityPack.HtmlNode item);
        Task<bool> IsFreeDelivery(HtmlAgilityPack.HtmlNode item);
        Task<bool> IsDiscount(HtmlAgilityPack.HtmlNode item);
    }
}
