﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer.DbContextLayer;

#nullable disable

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220530103839_addRefreshToken")]
    partial class addRefreshToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainLayer.Model.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Loại 1"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Loại 2"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Loại 3"
                        });
                });

            modelBuilder.Entity("DomainLayer.Model.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DomainLayer.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Image = "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg",
                            Name = "Mặt hàng 1",
                            Provider = "Nhà cung cấp 1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 3,
                            Image = "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg",
                            Name = "Mặt hàng 2",
                            Provider = "Nhà cung cấp 1"
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 2,
                            Image = "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg",
                            Name = "Mặt hàng 3",
                            Provider = "Nhà cung cấp 1"
                        });
                });

            modelBuilder.Entity("DomainLayer.Model.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DomainLayer.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("HashPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DomainLayer.Model.User_Role", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("RoleID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("User_Role");
                });

            modelBuilder.Entity("DomainLayer.Model.Product", b =>
                {
                    b.HasOne("DomainLayer.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DomainLayer.Model.User_Role", b =>
                {
                    b.HasOne("DomainLayer.Model.Role", "Roles")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Model.User", "Users")
                        .WithMany("UserRole")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DomainLayer.Model.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DomainLayer.Model.Role", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("DomainLayer.Model.User", b =>
                {
                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
