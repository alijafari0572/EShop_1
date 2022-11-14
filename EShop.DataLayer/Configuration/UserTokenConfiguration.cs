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
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasOne(UserToken => UserToken.User)
                .WithMany(UserToken => UserToken.UserTokens)
                .HasForeignKey(UserToken => UserToken.UserId);

            builder.ToTable("UserTokens");
        }
    }
}
