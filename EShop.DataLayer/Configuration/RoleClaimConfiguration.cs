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
    public class RoleClaimConfiguration:IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasOne(RoleClaim => RoleClaim.Role)
                .WithMany(RoleClaim => RoleClaim.RoleClaims)
                .HasForeignKey(RoleClaim => RoleClaim.RoleId);

            builder.ToTable("RoleClaims");
        }

    }
}
