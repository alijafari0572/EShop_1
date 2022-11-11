using EShop.DataLayer.Context;
using EShop.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Identity
{
    public class ApplicationRoleStore :
        RoleStore<Role, EShopDbContext, int, UserRole, RoleClaim>

    {
        public ApplicationRoleStore(IUnitOfWork uow, IdentityErrorDescriber describer = null) : base((EShopDbContext)uow, describer)
        {
        }
    }
}
