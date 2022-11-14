using EShop.DataLayer.Context;
using EShop.Entities.Identity;
using EShop.Services.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Identity
{
    public class UserManagerService
        : UserManager<User>
        ,IUserManagerService
    {
        public UserManagerService(
        IUserStoreServoce store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher,
        IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManagerService> logger)
            : base(
                  (UserStore<User, Role, EShopDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>)store,
                   optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger
                  )
        {
        }
    }
}
