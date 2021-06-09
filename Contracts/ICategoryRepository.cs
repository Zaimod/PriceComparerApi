using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetAllCategories();

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        Category GetCategoryById(int categoryId);

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        void CreateCategory(Category category);
    }
}
