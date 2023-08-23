using System.ComponentModel.DataAnnotations;

namespace AddServices.Models.FrontEndModels
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

/*
 postman > body raw jason 
 {  
    "FirstName" :"schema",
    "LastName" : " perera",
    "Email" : "lal2@gmail.com",
    "Password" : "Aspnetproj-73",
     "ConfirmPassword" : "Aspnetproj-73"
}
*/