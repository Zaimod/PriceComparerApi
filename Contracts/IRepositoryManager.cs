using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        /// <summary>
        /// Gets the store.
        /// </summary>
        /// <value>
        /// The store.
        /// </value>
        IStoreRepository store { get; }

        /// <summary>
        /// Gets the catalog.
        /// </summary>
        /// <value>
        /// The catalog.
        /// </value>
        ICatalogRepository catalog { get; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        ICategoryRepository category { get; }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        IProductRepository product { get; }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        /// 

        IFavouriteItemRepository favouriteItem { get; }

        Task SaveAsync();
    }
}
