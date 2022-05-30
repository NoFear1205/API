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
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder.HasKey(c=>c.CategoryID);
            modelBuilder.Property(c=>c.CategoryName).HasMaxLength(30).IsRequired();
        }
    }
}
