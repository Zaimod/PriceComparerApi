using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPartsRepository: IRepositoryBase<Parts>
    {
        IEnumerable<Parts> GetAllParts();
        Parts GetPartById(Guid Id);
        IEnumerable<Parts> GetByIds(IEnumerable<Guid> ids);
        void CreateParts(Parts parts);
    }
}
