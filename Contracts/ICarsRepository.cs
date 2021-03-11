using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICarsRepository : IRepositoryBase<Cars>
    {
        Task<IEnumerable<Cars>> GetAllCarsAsync();
        Task<Cars> GetCarByIdAsync(Guid carId);
        void CreateCar(Cars car);
    }
}
