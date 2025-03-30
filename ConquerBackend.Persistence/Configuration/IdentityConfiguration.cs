using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConquerBackend.Persistence.Constract;

namespace ConquerBackend.Persistence.Configuration
{
    internal sealed class AppUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.ToTable(DatabaseConstants.TableNames.UserRolesTable);

            builder.HasKey(x => new { x.RoleId, x.UserId });
        }
    }

    internal sealed class AppRoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.ToTable(DatabaseConstants.TableNames.RoleClaimsTable);

            builder.HasKey(x => x.RoleId);

            builder.Property(x => x.ClaimType)
                .HasColumnType("VARCHAR(4000)")
                .HasDefaultValue(string.Empty);

            builder.Property(x => x.ClaimValue)
               .HasColumnType("VARCHAR(4000)")
               .HasDefaultValue(string.Empty);
        }
    }

    internal sealed class AppUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            builder.ToTable(DatabaseConstants.TableNames.UserClaimsTable);

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.ClaimType)
                .HasColumnType("VARCHAR(4000)")
                .HasDefaultValue(string.Empty);

            builder.Property(x => x.ClaimValue)
               .HasColumnType("VARCHAR(4000)")
               .HasDefaultValue(string.Empty);
        }
    }

    internal sealed class AppUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
        {
            builder.ToTable(DatabaseConstants.TableNames.UserLoginsTable);

            builder.HasKey(x => x.UserId);
        }
    }

    internal sealed class AppUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
        {
            builder.ToTable(DatabaseConstants.TableNames.UserTokensTable);

            builder.HasKey(x => x.UserId);
        }
    }
}
