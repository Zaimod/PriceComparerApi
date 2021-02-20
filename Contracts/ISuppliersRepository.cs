using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISuppliersRepository: IRepositoryBase<Suppliers>
    {
        IEnumerable<Suppliers> GetAllSuppliers();

        Suppliers GetSupplierById(Guid supplierId);

        void CreateSupplier(Suppliers supplier);
    }
}
