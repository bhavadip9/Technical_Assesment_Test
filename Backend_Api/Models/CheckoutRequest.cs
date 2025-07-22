using System.ComponentModel.DataAnnotations;

namespace Backend_Api.Models
{
    public class CheckoutRequest
    {

        [Required(ErrorMessage = "Full Name is required")]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "Payment Method is required")]
        public required string PaymentMethod { get; set; }
    }
}
