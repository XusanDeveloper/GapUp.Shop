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
        Task<IQueryable<Product>> GetProducts(bool trackchanges);
        Task<IQueryable<Product>> GetProduct(Expression<Func<Product, bool>> expression, bool trackChanges);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Guid id, Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
