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
    public class CarsRepository: RepositoryBase<Cars>, ICarsRepository
    {
        public CarsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Cars>> GetAllCarsAsync() => await FindAll()
                .OrderBy(c => c.Brand)
                .ToListAsync();

        public async Task<Cars> GetCarByIdAsync(Guid carId) => await FindByCondition(car => car.Id.Equals(carId))
                .SingleOrDefaultAsync();

        public void CreateCar(Cars car)
        {
            Create(car);
        }
    }
}
