using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFavouriteItemRepository : IRepositoryBase<FavouriteItem>
    {
        /// <summary>
        /// Gets all favourite items.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FavouriteItem>> GetFavouriteItemsByUser(string userName);

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="favouriteItem">The favourite item.</param>
        /// <returns></returns>
        void AddFavouriteItem(FavouriteItem favouriteItem);

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="favouriteItem">The favourite item.</param>
        void DeleteItem(FavouriteItem favouriteItem);
    }
}
