using Backend_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        [HttpPost]
        public IActionResult Submit([FromBody] CheckoutRequest request)
        {          
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Validation failed." });
            }

            return Ok(new { success = true, message = "Form submitted successfully!" });
        }

       
        }
    
}
