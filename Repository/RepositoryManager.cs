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
        private ICarsRepository _cars;
        private ISuppliersRepository _suppliers;
        private IPartsRepository _parts;
        private ICategoryRepository _category;

        public ICarsRepository Cars
        {
            get
            {
                if(_cars == null)
                {
                    _cars = new CarsRepository(_repoContext);
                }

                return _cars;
            }
        }

        public ISuppliersRepository Suppliers
        {
            get
            {
                if (_suppliers == null)
                {
                    _suppliers = new SuppliersRepository(_repoContext);
                }

                return _suppliers;
            }
        }

        public IPartsRepository Parts
        {
            get
            {
                if(_parts == null)
                {
                    _parts = new PartsRepository(_repoContext);
                }

                return _parts;
            }
        }

        public ICategoryRepository Category
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
