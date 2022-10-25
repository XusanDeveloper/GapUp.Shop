using AutoMapper;
using GapUp.Data.Contracts;
using GapUp.Domain.Entites;
using GapUp.Services.DTO_s;
using GapUp.Services.Interfaces;

namespace GapUp.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<ProductViewModel> Create(ProductViewModel productViewModel)
        {
            var createdProduct = await productRepository.AddProduct((Product)productViewModel);

            return (ProductViewModel)createdProduct;

        }

        public async Task<bool> Delete(Guid id)
        {
            return await productRepository.DeleteProduct(id);
        }

        public async Task<ProductViewModel> Get(Guid id)
        {
            var product = await productRepository.GetProductAsync(id, trackChanges: false);
            
            return (ProductViewModel)product;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var products = await productRepository.GetAllProductsAsync(trackchanges: false);

            var productViewModel = mapper.Map<IEnumerable<ProductViewModel>>(products);

            return productViewModel;
        }

        public async Task<ProductViewModel> Update(Guid id, ProductViewModel productViewModel)
        {
            var updatedProduct = await productRepository.UpdateProduct(id, (Product)productViewModel);
            
            return (ProductViewModel)updatedProduct;
        }
    }
}
