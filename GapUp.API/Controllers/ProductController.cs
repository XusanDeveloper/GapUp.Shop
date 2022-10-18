using GapUp.Services.DTO_s;
using GapUp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GapUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await productService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductViewModel product)
        {
            return Ok(await productService.Create(product));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromForm] ProductViewModel productViewModel)
        {
            var updatedProduct = await productService.Update(id, productViewModel);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedProduct = await productService.Delete(id);
            if (deletedProduct)
                return NoContent();
            return NotFound();
        }
    }
}
