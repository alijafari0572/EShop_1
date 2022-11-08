using EShop.Common.Constants;
using EShop.Entities;
using EShop.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Common.MVC;
using EShop.Services.Contracts;

namespace EShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IViewRendererService _viewRendererService;

        public AccountController(UserManager<User> userManager,
            ILogger<AccountController> logger, IEmailSenderService emailSenderService, IViewRendererService viewRendererService)
        {
            _userManager = userManager;
            _logger = logger;
            _emailSenderService = emailSenderService;
            _viewRendererService = viewRendererService;
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
                    var activationCode =await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var body = await _viewRendererService.RenderViewToStringAsync(
                        "~/Views/EmailTemplates/_ActivationUserEmailTemplate.cshtml",
                        new RegisterEmailConfirmation_ViewModel()
                        {
                            UserName = model.UserName,
                            ActivationCode =activationCode,
                            CreatedDateTime = user.CreateDateTime.ToString()
                        }); //send Email
                    //await _emailSenderService.SendEmailAsync(
                    //    model.Email,
                    //    "فعال سازی حساب کاربری",
                    //    body

                    //);
                    return Json("Success");
                }

               errors.AddRange(result.Errors.Select(error => error.Description));
            }
            return BadRequest(errors);
        }
        [HttpPost]
        public IActionResult CheckUserName(string UserName)
        {
            return Json(true);
        }

        public IActionResult ConfirmEmail()
        {
            return View();
        }
    }
}
