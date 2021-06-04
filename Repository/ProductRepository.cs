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
        public ProductRepository(RepositoryContext repositoryContext)
               : base(repositoryContext)
        {
        }

        public async Task CreateProduct(Product product)
        {
            Create(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await FindAll()
                .OrderBy(c => c.title)
                .ToListAsync();

        public async Task<Product> GetProductById(int productId)
        {
            return FindByCondition(category => category.Id.Equals(productId)).FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId) => 
            await FindByCondition(c => c.categoryId == categoryId)
            .OrderBy(c => c.title)
            .ToListAsync();
    }
}
