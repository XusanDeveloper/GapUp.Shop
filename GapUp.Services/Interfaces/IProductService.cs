using GapUp.Services.DTO_s;

namespace GapUp.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> Create(ProductViewModel productViewModel);
        Task<ProductViewModel> Get(Guid id);
        Task<ProductViewModel> Update(Guid id, ProductViewModel productViewModel);
        Task<bool> Delete(Guid id);
    }
}
