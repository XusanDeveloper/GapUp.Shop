using GapUp.Data.Contracts;
using GapUp.Domain.Contexts;
using GapUp.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace GapUp.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GapUpDbContext dbContext;

        public ProductRepository(GapUpDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Guid id, Product product)
        {
            var updatedProduct = dbContext.Products.Attach(product);
            updatedProduct.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
