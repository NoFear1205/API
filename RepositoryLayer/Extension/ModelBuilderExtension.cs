using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryID = 1, CategoryName = "Loại 1" },
                new Category() { CategoryID = 2, CategoryName = "Loại 2" },
                new Category() { CategoryID = 3, CategoryName = "Loại 3" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, CategoryID = 1, Name = "Mặt hàng 1", Image = "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg", Provider="Nhà cung cấp 1" },
                new Product() { Id = 2, CategoryID = 3, Name = "Mặt hàng 2", Image = "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg", Provider = "Nhà cung cấp 1" },
                new Product() { Id = 3, CategoryID = 2, Name = "Mặt hàng 3", Image = "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg", Provider = "Nhà cung cấp 1" }
                );
        }
    }
}
