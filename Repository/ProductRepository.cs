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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
               : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return FindAll()
               .OrderBy(c => c.title)
               .ToList();
        }

        public Product GetProductById(int productId)
        {
            return FindByCondition(category => category.Id.Equals(productId))
                .FirstOrDefault();
        }
    }
}
