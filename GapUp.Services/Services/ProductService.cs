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

            return new ProductViewModel
            {
                Name = createdProduct.Name,
                PhotoUrl = createdProduct.PhotoUrl,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                type = createdProduct.type
            };

        }

        public async Task<bool> Delete(Guid id)
        {
            return await productRepository.DeleteProduct(id);
        }

        public async Task<ProductViewModel> Get(Guid id)
        {
            var product = await productRepository.GetProduct(id);
            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                PhotoUrl= product.PhotoUrl,
                Description= product.Description,
                Price= product.Price,
                type= product.type
            };
            return model;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var result = new List<ProductViewModel>();
            var products = await productRepository.GetProducts();
            foreach (var product in products)
            {
                var model = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    PhotoUrl= product.PhotoUrl,
                    Description= product.Description,   
                    Price= product.Price,
                    type= product.type
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<ProductViewModel> Update(Guid id, ProductViewModel productViewModel)
        {
            var updatedProduct = await productRepository.UpdateProduct(id, (Product)productViewModel);
            return new ProductViewModel
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                PhotoUrl = updatedProduct.PhotoUrl,
                Description = updatedProduct.Description,
                Price = updatedProduct.Price,
                type = updatedProduct.type
            };
        }
    }
}
