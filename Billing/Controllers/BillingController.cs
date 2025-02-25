using Billing.Models;
using Billing.Services.BillingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Billing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpPut]
        [Authorize]
        public IActionResult ProcessOrder([FromBody] Order order)
        {
            try
            {
                var receipt = _billingService.ProcessOrder(order);
                return Ok(receipt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }






}

