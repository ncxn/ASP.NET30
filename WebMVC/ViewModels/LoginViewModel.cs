using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Thư điện tử")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Phải nhập Email")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Phải nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ")]
        public bool RememberMe { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}
