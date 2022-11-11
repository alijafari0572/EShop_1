using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EShop.Entities
{
    public class RoleClaim:IdentityRoleClaim<int>
    {
        public virtual Role Role { get; set; }
    }
}
