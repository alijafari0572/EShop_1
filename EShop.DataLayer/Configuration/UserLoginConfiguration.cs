using EShop.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataLayer.Configuration
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasOne(UserLogin => UserLogin.User)
                 .WithMany(UserLogin => UserLogin.UserLogins)
                 .HasForeignKey(UserLogin => UserLogin.UserId);

            builder.ToTable("UserLogins");
        }
    }
}
