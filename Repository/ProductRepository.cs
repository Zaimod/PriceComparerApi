using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public ProductRepository(RepositoryContext repositoryContext)
               : base(repositoryContext)
        {
        }

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public async Task CreateProduct(Product product)
        {
            Create(product);
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts() => await FindAll()
                .OrderByDescending(c => c.numbReviews)
                .ToListAsync();

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int productId)
        {
            return FindByCondition(category => category.Id.Equals(productId)).FirstOrDefault();
        }

        /// <summary>
        /// Gets the products by category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId) => 
            await FindByCondition(c => c.categoryId == categoryId)
            .OrderByDescending(c => c.numbReviews)
            .ToListAsync();
    }
}
