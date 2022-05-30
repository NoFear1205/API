using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DbContextLayer
{
    internal class UserRoleEntityConfig : IEntityTypeConfiguration<User_Role>
    {
        public void Configure(EntityTypeBuilder<User_Role> builder)
        {
            builder.HasKey(sc => new { sc.RoleID, sc.UserID });

            builder
                .HasOne<User>(sc => sc.Users)
                .WithMany(s => s.UserRole)
                .HasForeignKey(sc => sc.UserID);


            builder
                .HasOne<Role>(sc => sc.Roles)
                .WithMany(s => s.UserRole)
                .HasForeignKey(sc => sc.RoleID);
        }
    }
}
