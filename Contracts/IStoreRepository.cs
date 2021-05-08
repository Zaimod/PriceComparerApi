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
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store> GetStoreByIdAsync(int storeId);
        void CreateStore(Store store);
    }
}
