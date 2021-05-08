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
    public class StoreRepository: RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Store>> GetStoresAsync() => await FindAll()
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Store> GetStoreByIdAsync(int carId) => await FindByCondition(car => car.Id.Equals(carId))
                .SingleOrDefaultAsync();

        public void CreateStore(Store car) => Create(car);
    }
}
