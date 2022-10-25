using GapUp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GapUp.Data.Contracts
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> GetAllProductsAsync(bool trackchanges);
        Task<Product> GetProductAsync(Guid id, bool trackChanges);
        void AddProduct(Product product);
        Task<Product> UpdateProduct(Guid id, Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
