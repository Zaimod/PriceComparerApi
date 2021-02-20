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
    public class PartsRepository : RepositoryBase<Parts>, IPartsRepository
    {
        public PartsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Parts> GetAllParts()
        {
            return FindAll()
                .OrderBy(c => c.Name)
                .ToList();
        }

        public IEnumerable<Parts> GetByIds(IEnumerable<Guid> ids)
        {
            return FindByCondition(x => ids.Contains(x.Id))
                .ToList();
        }

        public Parts GetPartById(Guid Id)
        {
            return FindByCondition(parts => parts.Id.Equals(Id))
                .FirstOrDefault();
        }

        public void CreateParts(Parts parts)
        {
            Create(parts);
        }
    }
}
