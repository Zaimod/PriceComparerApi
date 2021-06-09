using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICatalogRepository: IRepositoryBase<Catalog>
    {
        /// <summary>
        /// Gets the catalog.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Catalog>> GetCatalog();

        /// <summary>
        /// Gets the catalog by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<Catalog>> GetCatalogByProductId(int id);

        /// <summary>
        /// Gets the catalog by search.
        /// </summary>
        /// <param name="searchName">Name of the search.</param>
        /// <returns></returns>
        Task<IEnumerable<Catalog>> GetCatalogBySearch(string searchName);

        /// <summary>
        /// Gets the item of catalog by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Catalog GetItemOfCatalogById(int Id);

        /// <summary>
        /// Gets the name of the item of catalog by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns></returns>
        Catalog GetItemOfCatalogByName(string name, int storeId);

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        IEnumerable<Catalog> GetByIds(IEnumerable<int> ids);

        /// <summary>
        /// Creates the catalog.
        /// </summary>
        /// <param name="catalog">The catalog.</param>
        void CreateCatalog(Catalog catalog);

        /// <summary>
        /// Determines whether [is need to change price] [the specified URL].
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        Task<bool> isNeedToChangePrice(string url, double price);

        /// <summary>
        /// Changes the price.
        /// </summary>
        /// <param name="item">The item.</param>
        void ChangePrice(Catalog item);
    }
}
