using EShop.Common.Constants;
using EShop.Entities;
using EShop.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register_ViewModel model)
        {
            var errors = new List<string>();
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result=await _userManager.CreateAsync(user, model.Password);
               if (result.Succeeded)
                {
                    _logger.LogInformation(LogCods.RegisterCode,$"کاربر با نام {user.UserName} ثبت نام کرد. ");
                    var activationcode =await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //send Email
                    return Json("Success");
                }
               foreach(var error in result.Errors)
                {
                    errors.Add(error.Description);
                }

            };
            return BadRequest(errors);
        }
        [HttpPost]
        public IActionResult CheckUserName(string UserName)
        {
            return Json(true);
        }
    }
}
