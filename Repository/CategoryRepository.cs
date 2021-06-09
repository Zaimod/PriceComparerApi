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
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetAllCategories()
        {
            return FindAll()
               .OrderBy(c => c.Id)
               .ToList();
        }

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        public Category GetCategoryById(int categoryId)
        {
            return FindByCondition(category => category.Id.Equals(categoryId))
                .FirstOrDefault();
        }

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void CreateCategory(Category category)
        {
            Create(category);
        }
    }
}
