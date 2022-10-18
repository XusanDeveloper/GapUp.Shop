using GapUp.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
