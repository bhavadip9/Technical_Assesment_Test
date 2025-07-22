using Backend_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{

    
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        private readonly CheckoutDbContext _context;

        public CheckoutController(CheckoutDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Submit([FromBody] CheckoutRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Validation failed." });
            }

               _context.Add(request);
               _context.SaveChanges();
                return Ok(new { success = true, message = "Form submitted successfully!" });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { success = false, message = "An error occurred while processing your request." });
            }

           
        }


    }
    
}
