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
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public CatalogRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        /// <summary>
        /// Gets the catalog.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Catalog>> GetCatalog() => await FindAll()
                .OrderBy(c => c.Name)
                .ToListAsync();

        /// <summary>
        /// Gets the catalog by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Catalog>> GetCatalogByProductId(int id) => await FindByCondition(c => c.productId == id)
            .OrderBy(c => c.Name)
            .ToListAsync();

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public IEnumerable<Catalog> GetByIds(IEnumerable<int> ids)
        {
            return FindByCondition(x => ids.Contains(x.id))
                .ToList();
        }

        /// <summary>
        /// Gets the item of catalog by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Catalog GetItemOfCatalogById(int Id)
        {
            return FindByCondition(c => c.id.Equals(Id))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the name of the item of catalog by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns></returns>
        public Catalog GetItemOfCatalogByName(string name, int storeId)
        {
            Catalog result = FindByCondition(c => c.Name.Equals(name)).FirstOrDefault();

            if (result != null)
            {
                if (result.storeId != storeId)
                    return null;
                else
                    return result;
            }
            return result;
        }

        /// <summary>
        /// Creates the catalog.
        /// </summary>
        /// <param name="parts">The parts.</param>
        public void CreateCatalog(Catalog parts)
        {
            Create(parts);
        }

        /// <summary>
        /// Gets the catalog by search.
        /// </summary>
        /// <param name="searchName">Name of the search.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Catalog>> GetCatalogBySearch(string searchName)
        {
            return await FindByCondition(c => c.Name.Contains(searchName)).OrderBy(c => c.Name).ToListAsync();
        }

        /// <summary>
        /// Determines whether [is need to change price] [the specified URL].
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        public async Task<bool> isNeedToChangePrice(string url, double price)
        {
           double oldPrice = FindByCondition(c => c.Url.Equals(url)).FirstOrDefault().NewPrice;

            if (oldPrice != price)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Changes the price.
        /// </summary>
        /// <param name="item">The item.</param>
        public void ChangePrice(Catalog item)
        {
            Update(item);
        } 
    }
}
