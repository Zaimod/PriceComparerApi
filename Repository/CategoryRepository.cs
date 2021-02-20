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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Category> GetAllCategories()
        {
            return FindAll()
               .OrderBy(c => c.Name)
               .ToList();
        }

        public Category GetCategoryById(Guid categoryId)
        {
            return FindByCondition(category => category.Id.Equals(categoryId))
                .FirstOrDefault();
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }
    }
}
