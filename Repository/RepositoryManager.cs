using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repoContext;
        private IStoreRepository _store;
        private ICatalogRepository _catalog;
        private ICategoryRepository _category;
        private IProductRepository _product;
        public IStoreRepository store
        {
            get
            {
                if(_store == null)
                {
                    _store = new StoreRepository(_repoContext);
                }

                return _store;
            }
        }
        public IProductRepository product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }

                return _product;
            }
        }
        public ICatalogRepository catalog
        {
            get
            {
                if(_catalog == null)
                {
                    _catalog = new CatalogRepository(_repoContext);
                }

                return _catalog;
            }
        }

        public ICategoryRepository category
        {
            get
            {
                if(_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }

                return _category;
            }
        }

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public Task SaveAsync() => _repoContext.SaveChangesAsync();
    }
}
