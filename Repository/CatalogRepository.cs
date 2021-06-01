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
    public class CatalogRepository : RepositoryBase<Catalog>, ICatalogRepository
    {
        public CatalogRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Catalog>> GetCatalog() => await FindAll()
                .OrderBy(c => c.Name)
                .ToListAsync();

        public IEnumerable<Catalog> GetByIds(IEnumerable<int> ids)
        {
            return FindByCondition(x => ids.Contains(x.id))
                .ToList();
        }

        public Catalog GetItemOfCatalogById(int Id)
        {
            return FindByCondition(c => c.id.Equals(Id))
                .FirstOrDefault();
        }

        public Catalog GetItemOfCatalogByName(string name)
        {
            return FindByCondition(c => c.Name.Equals(name))
                .FirstOrDefault();
        }

        public void CreateCatalog(Catalog parts)
        {
            Create(parts);
        }

        public async Task<IEnumerable<Catalog>> GetCatalogBySearch(string searchName)
        {
            return await FindByCondition(c => c.Name.Contains(searchName)).OrderBy(c => c.Name).ToListAsync();
        }
        public async Task<bool> isNeedToChangePrice(string url, double price)
        {
           double oldPrice = FindByCondition(c => c.Url.Equals(url)).FirstOrDefault().NewPrice;

            if (oldPrice != price)
                return true;
            else
                return false;
        }

        public void ChangePrice(Catalog item)
        {
            Update(item);
        }

        
    }
}
