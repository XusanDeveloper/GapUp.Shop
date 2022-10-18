using GapUp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapUp.Data.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> GetProduct(Guid id);
        Task<Product> UpdateProduct(Guid id, Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
