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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(UserRole => UserRole.Role)
                .WithMany(UserRole => UserRole.UserRoles)
                .HasForeignKey(UserRole => UserRole.RoleId);

            builder.HasOne(UserRole => UserRole.User)
                .WithMany(UserRole => UserRole.UserRoles)
                .HasForeignKey(UserRole => UserRole.UserId);

            builder.ToTable("UserRoles");
        }
    }
}
