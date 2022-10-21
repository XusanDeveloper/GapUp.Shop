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

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
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
            var product = await productRepository.GetProduct(id);
            
            return (ProductViewModel)product;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var result = new List<ProductViewModel>();
            var products = await productRepository.GetProducts();
            foreach (var product in products)
            {
                result.Add((ProductViewModel)product);
            }
            return result;
        }

        public async Task<ProductViewModel> Update(Guid id, ProductViewModel productViewModel)
        {
            var updatedProduct = await productRepository.UpdateProduct(id, (Product)productViewModel);
            
            return (ProductViewModel)updatedProduct;
        }
    }
}
