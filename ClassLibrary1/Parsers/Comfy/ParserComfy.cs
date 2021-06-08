using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ParserApplication.Parsers.Comfy
{
    public class ParserComfy : IParser
    {
        List<CatalogForCreationDto> dtos;
        CatalogForCreationDto dto;
        GetComponentsComfy componentsComfy;

        public ParserComfy(int storeId, int categoryId, int productId, IRepositoryManager repository)
        {
            dtos = new List<CatalogForCreationDto>();
            dto = new CatalogForCreationDto();
            componentsComfy = new GetComponentsComfy(storeId, categoryId, productId, repository);

        }

        async public Task<List<CatalogForCreationDto>> Run(string searchQuery)
        {
            string pathToDriver = @"D:\Distrib\seleniumDriver";
            string url = "";
            var chromeOptions = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(pathToDriver, chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(10));
            try
            {
                driver.Navigate().GoToUrl("https://comfy.ua/ua/smartfon/warehouse__any__brand__apple/");

                Thread.Sleep(100);
                url += "\n" + driver.Url;

                driver.Close();
                driver.Quit();

                try
                {
                    HttpClientHandler handler = new HttpClientHandler();
                    handler.AllowAutoRedirect = true;

                    var httpClient = new HttpClient(handler);
                    var html = await httpClient.GetStringAsync(url);

                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(html);

                    var catalog = htmlDocument.DocumentNode.Descendants("div")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("product-item products-list__item js-item")).ToList();

                    foreach (var item in catalog)
                    {
                        bool isNeedToGet = componentsComfy.CheckNameForProduct(item).Result;
                        bool ifAviability = componentsComfy.CheckIsAvaibility(item).Result;
                        if (isNeedToGet && ifAviability)
                        {
                            await componentsComfy.Create(item);
                            var dto = await componentsComfy.GetDto();

                            if (dto.Name != null)
                                dtos.Add(dto);
                        }
                    }

                    return dtos;
                }
                catch (Exception)
                {
                    driver.Close();
                    driver.Quit();

                    throw;
                }
            }
            catch (Exception)
            {
                driver.Close();
                driver.Quit();

                throw;
            }
        }
    }
}
