using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Areas.Identity.ViewMedels
{
    public class RegisterViewModel
    {
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} không đúng định dạng")]
        [Display(Name = "Thư điện tử")]
        public string Email { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "{0} có độ dài ít nhất {2} và nhiều nhất {1} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        public UrlAttribute LoginURL { get; set; }
    }
}
