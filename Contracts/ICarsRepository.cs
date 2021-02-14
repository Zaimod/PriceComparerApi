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
        IEnumerable<Cars> GetAllCars();

        Cars GetCarById(Guid carId);
    }
}
