using Contracts;
using Entities.DataTransferObjects;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParserApplication.Parsers.Comfy
{ 
    public class GetComponentsComfy : IComponent
    {
        CatalogForCreationDto dto;
        private IRepositoryManager _repository;
        int storeId { get; set; }
        int categoryId { get; set; }
        int productId { get; set; }

        public GetComponentsComfy(int storeId, int categoryId, int productId, IRepositoryManager repository)
        {
            this.storeId = storeId;
            this.categoryId = categoryId;
            this.productId = productId;
            _repository = repository;
        }

        async public Task Create(HtmlNode item)
        {
            dto = new CatalogForCreationDto();

            dto.Name = await GetName(item);
            dto.NewPrice = await GetNewPrice(item);
            dto.Price = await GetPrice(item);
            dto.Url = await GetUrl(item);
            dto.FreeDelivery = await IsFreeDelivery(item);
            dto.Discount = await IsDiscount(item);
            dto.NumbReviews = 0;
            dto.LastModified = DateTime.Now;
            dto.categoryId = categoryId;
            dto.storeId = storeId;
            dto.productId = productId;

        }

        async public Task<string> GetName(HtmlNode item)
        {
            string text = item.Descendants("a")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("product-item__name-link js-gtm-product-title")).FirstOrDefault().InnerText;

            text = Regex.Replace(text, @"[^a-zA-z0-9!@#]+", " ").Trim();
            return text;
        }

        async public Task<double> GetNewPrice(HtmlNode item)
        {
            string text = "";

            text = item.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("price-box__content price-box__content_special"))
                .FirstOrDefault().Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("price-value")).FirstOrDefault().InnerText;



            text = Regex.Replace(text, @"[^0-9.]", "").Trim();
            return Convert.ToDouble(text);
        }

        async public Task<double> GetPrice(HtmlNode item)
        {
            string text = "";

            if (item.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("price-box__content price-box__content_old"))
                .FirstOrDefault().Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("price-value")).FirstOrDefault().InnerText != "")
            {
                text = item.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("price-box__content price-box__content_old"))
                .FirstOrDefault().Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("price-value")).FirstOrDefault().InnerText;
            }
            else
            {
                text = item.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("price-box__content price-box__content_special"))
                .FirstOrDefault().Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("price-value")).FirstOrDefault().InnerText;
            }

            text = Regex.Replace(text, @"[^0-9.]", "").Trim();
            return Convert.ToDouble(text);
        }

        async public Task<string> GetUrl(HtmlNode item)
        {
            string url = item.Descendants("a")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("product-item__name-link js-gtm-product-title"))
                .FirstOrDefault().GetAttributeValue("href", "").Trim();

            return url;
        }

        async public Task<bool> IsFreeDelivery(HtmlNode item)
        {
            if (item.Descendants("img").Where(node => node.GetAttributeValue("alt", null).Contains("Доставка за 1 гривню")).FirstOrDefault() == null)
                return false;

            return true;
        }

        async public Task<bool> IsDiscount(HtmlNode item)
        {
            if (dto.NewPrice.Equals(dto.Price))
                return false;

            return true;
        }

        async public Task<bool> CheckNameForProduct(HtmlNode item)
        {
            string name = await GetName(item);


            List<string> excludeNames = new List<string>();
            excludeNames.AddRange(_repository.product.GetProductById(productId).Result.exclude.Split(", "));


            if (!name.Contains(_repository.product.GetProductById(productId).Result.title, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else if (name.Contains(_repository.product.GetProductById(productId).Result.title, StringComparison.OrdinalIgnoreCase))
            {
                if (excludeNames.FirstOrDefault() == "")
                    return true;
                if (excludeNames.Any(n => name.Contains(n, StringComparison.CurrentCultureIgnoreCase)))
                    return false;
            }
            return true;

        }

        async public Task<bool> CheckIsAvaibility(HtmlNode item)
        {
            if (item.Descendants("span").Where(node => node.GetAttributeValue("class", "").Equals("product-item__informer product-popup__link product-popup__link_bold js-informer ")).FirstOrDefault() == null)
                return true;

            return false;
        }

        async public Task<CatalogForCreationDto> GetDto()
        {
            return dto;
        }
    }
}
