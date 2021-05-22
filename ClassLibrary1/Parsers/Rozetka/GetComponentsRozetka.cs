using Contracts;
using Entities.DataTransferObjects;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParserApplication.Parsers.Rozetka
{
    public class GetComponentsRozetka : IComponent
    {
        CatalogForCreationDto dto; 
        private IRepositoryManager _repository;
        int storeId { get; set; }
        int categoryId { get; set; }
        int productId { get; set; }

        public GetComponentsRozetka(int storeId, int categoryId, int productId, IRepositoryManager repository)
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
            CheckNameForProduct();
        }

        async public Task<string> GetName(HtmlNode item)
        {
            string text = item.Descendants("a")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("goods-tile__heading")).FirstOrDefault().InnerText;

            text = Regex.Replace(text, @"[^a-zA-z0-9!@#]+", " ").Trim();
            return text;
        }

        async public Task<double> GetNewPrice(HtmlNode item)
        {
            string text = "";

            if (item.Descendants("div").Where(node => node.GetAttributeValue("class", "")
            .Contains("goods-tile__price price--red")).FirstOrDefault() != null)
            {
                text = item.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("goods-tile__price price--red")).FirstOrDefault().Descendants("p")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("ng-star-inserted")).FirstOrDefault().InnerText;
            }
            else
            {
                text = item.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("goods-tile__price ng-star-inserted")).FirstOrDefault().Descendants("p")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("ng-star-inserted")).FirstOrDefault().InnerText;
            }
               
            

            text = Regex.Replace(text, @"[^0-9.]", "").Trim();
            return Convert.ToDouble(text);
        }

        async public Task<double> GetPrice(HtmlNode item)
        {
            string text = "";

            if (item.Descendants("div").Where(node => node.GetAttributeValue("class", "")
            .Equals("goods-tile__price--old price--gray ng-star-inserted")).FirstOrDefault().InnerText != "")
            {
                text = item.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("goods-tile__price--old price--gray ng-star-inserted"))
                    .FirstOrDefault().InnerText;
            }
            else
            {
                text = item.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("goods-tile__price ng-star-inserted")).FirstOrDefault().Descendants("p")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("ng-star-inserted")).FirstOrDefault().InnerText;
            }

            text = Regex.Replace(text, @"[^0-9.]", "").Trim();
            return Convert.ToDouble(text);
        }

        async public Task<string> GetUrl(HtmlNode item)
        {
            var url = item.Descendants("a").First()
                .GetAttributeValue("href", null).Trim();

            return url;
        }

        async public Task<bool> IsFreeDelivery(HtmlNode item)
        {
            if(item.Descendants("img").Where(node => node.GetAttributeValue("alt", null).Contains("Безкоштовна доставка")).FirstOrDefault() == null)
                return false;

            return true;
        }

        async public Task<bool> IsDiscount(HtmlNode item)
        {
            if (dto.NewPrice.Equals(dto.Price))
                return false;

            return true;
        }

        async public void CheckNameForProduct()
        {
            List<string> excludeNames = new List<string>();
            excludeNames.AddRange(_repository.product.GetProductById(productId).exclude.Split(", "));


            if (!dto.Name.Contains(_repository.product.GetProductById(productId).title, StringComparison.OrdinalIgnoreCase))
            {
                dto.Name = null;
            }
            else if(dto.Name.Contains(_repository.product.GetProductById(productId).title, StringComparison.OrdinalIgnoreCase))
            {
                if (excludeNames.Any(name => dto.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)))
                    dto.Name = null;
            }

           
        }

        async public Task<CatalogForCreationDto> GetDto()
        {
            return dto;
        }
    }
}
