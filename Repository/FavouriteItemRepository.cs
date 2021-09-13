using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FavouriteItemRepository : RepositoryBase<FavouriteItem>, IFavouriteItemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FavouriteItemRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public FavouriteItemRepository(RepositoryContext repositoryContext)
               : base(repositoryContext)
        {
        }

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="favouriteItem">The favourite item.</param>
        public void AddFavouriteItem(FavouriteItem favouriteItem) => Create(favouriteItem);

        /// <summary>
        /// Gets all favourite items.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FavouriteItem>> GetFavouriteItemsByUser(string userName)
        {
            return await FindByCondition(u => u.userNameId == userName).Include(f => f.catalog).ToListAsync();
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="favouriteItem">The favourite item.</param>
        public void DeleteItem(FavouriteItem favouriteItem)
        {
            Delete(favouriteItem);
        }
    }
}
