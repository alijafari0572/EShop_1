using EShop.DataLayer.Context;
using EShop.Entities.Identity;
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
    public class UserStoreService
        :UserStore<User,Role,EShopDbContext,int,UserClaim,UserRole,UserLogin,UserToken,RoleClaim>
        , IUserStoreServoce
    {
        public UserStoreService(
            IUnitOfWork uow, IdentityErrorDescriber describer = null)
        :base((EShopDbContext)uow,describer)
        { 
        }
    }
}
