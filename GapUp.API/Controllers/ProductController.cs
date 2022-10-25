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
        private readonly ILoggerManager logger;

        public ProductController(IProductService productService, ILoggerManager logger)
        {
            this.productService = productService;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAll(trackchanges: false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await productService.Get(id);
            
            if (product == null)
            {
                logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(await productService.Get(id));
            }
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
