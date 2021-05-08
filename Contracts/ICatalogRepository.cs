using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICatalogRepository: IRepositoryBase<Catalog>
    {
        IEnumerable<Catalog> GetCatalog();
        Catalog GetItemOfCatalogById(int Id);
        Catalog GetItemOfCatalogByName(string name);
        IEnumerable<Catalog> GetByIds(IEnumerable<int> ids);
        void CreateCatalog(Catalog catalog);
    }
}
