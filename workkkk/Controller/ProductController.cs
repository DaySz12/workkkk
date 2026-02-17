using Microsoft.AspNetCore.Mvc;
using workkkk.Interface;
using workkkk.Service;
using workkkk.Viewmodel;

namespace workkkk.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService extService;

        public ProductController(IProductService service)
        {
            extService = service;
        }

        [HttpGet("ProductListById")]
        public async Task<IActionResult> ProductListById(string productcode)
        {
            try
            {
                var result = await extService.ProductListById(productcode);
                if (result == null || result.Count == 0)
                {
                    return NotFound("No products found with the given product code.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("InsertProduct")]
        public async Task<Response<ProductView>> InsertProduct(ProductView model)
        {
            var result = await extService.InsertProduct(model);
            return new Response<ProductView>
            {
                Result = model, Message = "success", Status = 200 
            };
        }
            
    }
}
            
