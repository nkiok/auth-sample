using System.ComponentModel.DataAnnotations;

namespace AuthSample.Features.Account.Models
{
    public class PasswordSetupViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        public string UserId { get; set; }

        public string Code { get; set; }
    }
}
