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

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
