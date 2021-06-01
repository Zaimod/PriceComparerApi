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

namespace ParserApplication.Parsers.Rozetka
{
    public class ParserRozetka : IParser
    {
        List<CatalogForCreationDto> dtos;
        CatalogForCreationDto dto;
        GetComponentsRozetka componentsRozetka;

        public ParserRozetka(int storeId, int categoryId, int productId, IRepositoryManager repository)
        {
            dtos = new List<CatalogForCreationDto>();
            dto = new CatalogForCreationDto();
            componentsRozetka = new GetComponentsRozetka(storeId, categoryId, productId, repository);
            
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
                driver.Navigate()
                    .GoToUrl("https://rozetka.com.ua/ua/");
                var seacrhItem = driver.FindElement(By.Name("search"));
                seacrhItem.SendKeys(searchQuery);

                driver.FindElement(By.ClassName("search-form__submit")).Click();

                Thread.Sleep(10);

                url = driver.Url;

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
                        .Equals("goods-tile ng-star-inserted")).ToList();

                    foreach (var item in catalog)
                    {
                        bool isNeedToGet = componentsRozetka.CheckNameForProduct(item).Result;

                        if (isNeedToGet)
                        {
                            await componentsRozetka.Create(item);
                            var dto = await componentsRozetka.GetDto();

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
