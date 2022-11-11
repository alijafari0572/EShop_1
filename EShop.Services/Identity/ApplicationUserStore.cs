using EShop.DataLayer.Context;
using EShop.Entities;
using EShop.Services.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Identity
{
    internal class ApplicationUserStore
        :UserStore<User,Role,EShopDbContext,int,UserClaim,UserRole,UserLogin,UserToken,RoleClaim>
        , IApplicationUserStore
    {
        public ApplicationUserStore(
            IUnitOfWork uow, IdentityErrorDescriber describer = null)
        :base((EShopDbContext)uow,describer)
        { 
        }
    }
}
