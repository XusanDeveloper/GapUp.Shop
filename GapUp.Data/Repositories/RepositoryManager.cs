using GapUp.Data.Contracts;
using GapUp.Domain.Contexts;

namespace GapUp.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private GapUpDbContext _repositoryContext;
        private IProductRepository _productRepository;

        public RepositoryManager(GapUpDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_repositoryContext);
                return _productRepository;
            }
        }

      

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
