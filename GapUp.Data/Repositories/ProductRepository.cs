using GapUp.Data.Contracts;
using GapUp.Domain.Contexts;
using GapUp.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace GapUp.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly GapUpDbContext dbContext;
                                                            
        public ProductRepository(GapUpDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await dbContext.Products.AddAsync(product);
            return product;
        }
        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                Delete(product);
                return true;
            }
            return false;
        }

        public async Task<Product> GetProductAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();


        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<Product> UpdateProduct(Guid id, Product product)
        {
            var updatedProduct = dbContext.Products.Attach(product);
            updatedProduct.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return product;
        }

     
    }
}
