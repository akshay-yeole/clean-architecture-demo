using System.ComponentModel.DataAnnotations;

namespace application.Dtos
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmedPassword { get; set; }




    }
}
