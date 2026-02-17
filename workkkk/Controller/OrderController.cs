

using Microsoft.AspNetCore.Mvc;
using workkkk.Interface;
using workkkk.Viewmodel;

namespace workkkk.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService extService;

        public OrderController(IOrderService service)
        {
            extService = service;
        }
        [HttpGet("OrderList")]
        public async Task<IActionResult> OrderList(int customerid, string status)
        {
            try
            {
                var result = await extService.OrderList(customerid, status);
                if (result == null || result.Count == 0)
                {
                    return NotFound("No orders found for the given customer ID and status.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("OrderListById")]
        public async Task<IActionResult> OrderListById(int Id)
        {
            try
            {
                var result = await extService.OrderListById(Id);
                if (result == null || result.Count == 0)
                {
                    return NotFound("No orders found with the given ID.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("InsertOrder")]
        public async Task<IActionResult> InsertOrder(OrderView model)
        {
            try
            {
                var result = await extService.InsertOrder(model);
                return Ok(new Response<OrderView>
                {
                    Result = model,
                    Message = "success",
                    Status = 200
                });
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
