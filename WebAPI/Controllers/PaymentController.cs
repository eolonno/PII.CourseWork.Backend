using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Payment() // Test
        {
            var result = _paymentService.Payment();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("discount")]
        public IActionResult GetDiscount(int userId)
        {
            var result = _paymentService.GetDiscount(userId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}