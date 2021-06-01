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
        Task<IEnumerable<Catalog>> GetCatalog();
        Task<IEnumerable<Catalog>> GetCatalogBySearch(string searchName);
        Catalog GetItemOfCatalogById(int Id);
        Catalog GetItemOfCatalogByName(string name);
        IEnumerable<Catalog> GetByIds(IEnumerable<int> ids);
        void CreateCatalog(Catalog catalog);

        Task<bool> isNeedToChangePrice(string url, double price);
        void ChangePrice(Catalog item);
    }
}
