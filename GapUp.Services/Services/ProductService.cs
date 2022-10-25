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
            var product = mapper.Map<Product>(productViewModel);

            var createdProduct = await productRepository.AddProduct(product);

            var productView = mapper.Map<ProductViewModel>(createdProduct);
            
            return productView;

        }

        public async Task<bool> Delete(Guid id)
        {
            return await productRepository.DeleteProduct(id);
        }

        public async Task<ProductViewModel> Get(Guid id)
        {
            var product = await productRepository.GetProductAsync(id, trackChanges: false);
            
            var productView = mapper.Map<ProductViewModel>(product);

            return productView;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll(bool trackchanges)
        {
            var products = await productRepository.GetAllProductsAsync(trackchanges: false);

            var productViewModel = mapper.Map<Product>(products);

            return (IEnumerable<ProductViewModel>)productViewModel;
        }

        public async Task<ProductViewModel> Update(Guid id, ProductViewModel productViewModel)
        {
            var productEntity = mapper.Map<Product>(productViewModel);

            var updatedProduct = await productRepository.UpdateProduct(id, productEntity);

            var productView = mapper.Map<ProductViewModel>(updatedProduct);
            
            return productView;
        }
    }
}
