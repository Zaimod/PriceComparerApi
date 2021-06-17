using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparerAPI.Tests.Repository
{
    public class CatalogRepositoryForTest : ICatalogRepository
    {
        List<Catalog> catalogs;

        public CatalogRepositoryForTest()
        {
            catalogs = new List<Catalog>()
            {

            }
        }

        public void ChangePrice(Catalog item)
        {
            throw new NotImplementedException();
        }

        public void Create(Catalog entity)
        {
            throw new NotImplementedException();
        }

        public void CreateCatalog(Catalog catalog)
        {
            throw new NotImplementedException();
        }

        public void Delete(Catalog entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Catalog> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Catalog> FindByCondition(Expression<Func<Catalog, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Catalog> GetByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Catalog>> GetCatalog()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Catalog>> GetCatalogByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Catalog>> GetCatalogBySearch(string searchName)
        {
            throw new NotImplementedException();
        }

        public Catalog GetItemOfCatalogById(int Id)
        {
            throw new NotImplementedException();
        }

        public Catalog GetItemOfCatalogByName(string name, int storeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isNeedToChangePrice(string url, double price)
        {
            throw new NotImplementedException();
        }

        public void Update(Catalog entity)
        {
            throw new NotImplementedException();
        }
    }
}
