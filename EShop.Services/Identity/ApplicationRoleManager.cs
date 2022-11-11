using EShop.DataLayer.Context;
using EShop.Entities;
using EShop.Services.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Identity
{
    public class ApplicationRoleManager : RoleManager<Role>
        , IApplicationRoleManager
    {
        public ApplicationRoleManager(
            IApplicationRoleStore store,
            IEnumerable<IRoleValidator<Role>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<ApplicationRoleManager> logger)
            : base(
                  (RoleStore<Role, EShopDbContext, int, UserRole, RoleClaim>) store,
                  roleValidators, keyNormalizer, errors, logger
                  )
        {
        }
    }
}
