using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStoreRepository : IRepositoryBase<Store>
    {
        /// <summary>
        /// Gets the stores asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Store>> GetStoresAsync();

        /// <summary>
        /// Gets the store by identifier asynchronous.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns></returns>
        Task<Store> GetStoreByIdAsync(int storeId);

        /// <summary>
        /// Creates the store.
        /// </summary>
        /// <param name="store">The store.</param>
        void CreateStore(Store store);
    }
}
