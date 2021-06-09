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
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public StoreRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        /// <summary>
        /// Gets the stores asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Store>> GetStoresAsync() => await FindAll()
                .OrderBy(c => c.Name)
                .ToListAsync();

        /// <summary>
        /// Gets the store by identifier asynchronous.
        /// </summary>
        /// <param name="carId">The car identifier.</param>
        /// <returns></returns>
        public async Task<Store> GetStoreByIdAsync(int carId) => await FindByCondition(car => car.Id.Equals(carId))
                .SingleOrDefaultAsync();

        /// <summary>
        /// Creates the store.
        /// </summary>
        /// <param name="car">The car.</param>
        public void CreateStore(Store car) => Create(car);
    }
}
