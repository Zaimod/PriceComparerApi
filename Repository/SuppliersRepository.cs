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
    public class SuppliersRepository: RepositoryBase<Suppliers>, ISuppliersRepository
    {
        public SuppliersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Suppliers> GetAllSuppliers()
        {
            return FindAll()
                .OrderBy(c => c.Name)
                .ToList();
        }

        public Suppliers GetSupplierById(Guid supplierId)
        {
            return FindByCondition(supplier => supplier.Id.Equals(supplierId))
                .FirstOrDefault();
        }

        public void CreateSupplier(Suppliers supplier)
        {
            Create(supplier);
        }
    }
}
