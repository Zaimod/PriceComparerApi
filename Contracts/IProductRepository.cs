using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAllProducts();

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<Product> GetProductById(int productId);

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        Task CreateProduct(Product product);

        /// <summary>
        /// Gets the products by category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
    }
}
