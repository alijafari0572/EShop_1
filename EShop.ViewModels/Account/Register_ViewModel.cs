using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;
using EShop_1.Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace EShop.ViewModels.Account
{
    public class Register_ViewModel
    {
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
        [MinLength(3,ErrorMessage =AttributesErrorMessages.MinLengthMessage)]
        [MaxLength(30,ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
        [RegularExpression(@"^\w+$", ErrorMessage = "نام کاربری باید از حروف انگلیسی تشکیل شده باشد")]
        [Remote("CheckUserName", "Account", null,
            ErrorMessage =AttributesErrorMessages.RemoteMessage, HttpMethod = "POST")]
       // [RegularExpression(@"^\w+$", ErrorMessage = "نام کاربری باید از حروف انگلیسی تشکیل شده باشد")]
        public string UserName { get; set; }
        [Display(Name ="ایمیل")]
        [Required(ErrorMessage =AttributesErrorMessages.RequiredMessage)]
        [EmailAddress(ErrorMessage =AttributesErrorMessages.RegularExpressionMessage)]

        public string Email { get; set; }
        [Display(Name ="رمز عبور")]
        [Required(ErrorMessage =AttributesErrorMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
        [MaxLength(50,ErrorMessage =AttributesErrorMessages.MaxLengthMessage)]
        public string Password { get; set; }
        [Display(Name ="تکرار رمز عبور")]
        [Required(ErrorMessage =AttributesErrorMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage =AttributesErrorMessages.CompareMessage)]
        public string ConfirmPassword { get; set; }

    }
}
