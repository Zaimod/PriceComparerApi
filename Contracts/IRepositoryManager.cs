using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IStoreRepository store { get; }
        ICatalogRepository catalog { get; }
        ICategoryRepository category { get; }
        IProductRepository product { get; }
        Task SaveAsync();
    }
}
