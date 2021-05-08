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
    public class CatalogRepository : RepositoryBase<Catalog>, ICatalogRepository
    {
        public CatalogRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Catalog> GetCatalog()
        {
            return FindAll()
                .OrderBy(c => c.Name)
                .ToList();
        }

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
    }
}
