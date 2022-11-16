using EShop_1.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels.Account
{
    public class Login_ViewModel
    {
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
        [MinLength(3, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
        [MaxLength(30, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
        public string UserName { get; set; }
        [Display(Name ="رمز عبور")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
        public string Password { get; set; }
        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }

    }
}
