using EShop.Common.Constants;
using EShop.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Common.MVC;
using EShop.Services.Contracts;
using EShop.Entities.Identity;
using EShop.Services.Contracts.Identity;
using EShop.Services.Identity;
using System;

namespace EShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagerService _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IViewRendererService _viewRendererService;
        private readonly ISignInManagerService _signInManagerService;

        public AccountController(IUserManagerService userManager,
            ILogger<AccountController> logger,
            IEmailSenderService emailSenderService,
            IViewRendererService viewRendererService,
            ISignInManagerService signInManagerService)
        {
            _userManager = userManager;
            _logger = logger;
            _emailSenderService = emailSenderService;
            _viewRendererService = viewRendererService;
            _signInManagerService = signInManagerService;
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
                user.CreateDateTime = DateTime.Now;
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
            else
            {
                errors.Add(PublicConstantStrings.ModelStateErrorMassage);
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
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl, Login_ViewModel model)
        {
            var errors = new List<string>();

            if (ModelState.IsValid)
            {
                var user =await _userManager.FindByNameAsync(model.UserName);
                if (user is null)
                {
                    errors.Add("نام کاربری یا رمز عبور اشتباه است");
                }
                else if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    errors.Add("لطفا حساب کاربری خود را فعال کنید");
                }
                else
                {
                    var result = await _signInManagerService.CheckPasswordSignInAsync(user, model.Password, model.RememberMe);
                    if (result.Succeeded)
                    {
                        return Ok("Success");
                    }
                    errors.Add("نام کاربری یا رمز عبور اشتباه است");
                }

            }
            else
                errors.Add(PublicConstantStrings.ModelStateErrorMassage);

            return BadRequest();
        }
    }
}
