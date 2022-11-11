﻿using EShop.Entities;
using EShop.Services.Contracts.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Identity
{
    public class ApplicationSignInManager : SignInManager<User>
    {
        public ApplicationSignInManager(
            IApplicationUserManager userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<ApplicationSignInManager> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<User> confirmation)
            : base(
                  (UserManager<User>)userManager,
                  contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation
                  )
        {
        }
    }
}
