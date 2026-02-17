using Microsoft.AspNetCore.Mvc;
using workkkk.Interface;
using workkkk.Viewmodel;

namespace workkkk.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService extService;

        public CustomerController(ICustomerService service)
        {
            extService = service;
        }

        [HttpGet("CustomerlistById")]
        public async Task<IActionResult> CustomerlistById(string code)
        {
            try
            {
                var result = await extService.CustomerlistById(code);
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

        [HttpPost("InsertCustomer")]
        public async Task<Response<CustomerView>> InsertCustomer(CustomerView model)
        {
            
            


                var result = await extService.InsertCustomer(model);
                return new Response<CustomerView>
                {
                    Result = model,
                    Message = "success",
                    Status = 200
                };
            }
            
        }

    }

