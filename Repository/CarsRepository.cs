using Contracts;
using Entities;
using Entities.Models;
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

        public IEnumerable<Cars> GetAllCars()
        {
            return FindAll()
                .OrderBy(c => c.Brand)
                .ToList();
        }

        public Cars GetCarById(Guid carId)
        {
            return FindByCondition(car => car.Id.Equals(carId))
                .FirstOrDefault();
        }

        public void CreateCar(Cars car)
        {
            Create(car);
        }
    }
}
