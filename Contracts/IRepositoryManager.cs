using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICarsRepository Cars { get; }
        ISuppliersRepository Suppliers { get; }
        IPartsRepository Parts { get; }
        ICategoryRepository Category { get; }
        Task SaveAsync();
    }
}
