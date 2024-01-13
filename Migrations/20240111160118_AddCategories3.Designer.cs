﻿// <auto-generated />
using System;
using Ilies_Dragos_Restaurant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ilies_Dragos_Restaurant.Migrations
{
    [DbContext(typeof(Ilies_Dragos_RestaurantContext))]
    [Migration("20240111160118_AddCategories3")]
    partial class AddCategories3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("MenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.MenuCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MenuCategories");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.MenuCategoryAssignment", b =>
                {
                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.Property<int>("MenuCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.HasKey("MenuID", "MenuCategoryID");

                    b.HasIndex("MenuCategoryID");

                    b.ToTable("MenuCategoryAssignments");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.MenuItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuID")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrarFunctionare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.RestaurantCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("RestaurantCategories");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.RestaurantCategoryAssignment", b =>
                {
                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.HasKey("RestaurantID", "RestaurantCategoryID");

                    b.HasIndex("RestaurantCategoryID");

                    b.ToTable("RestaurantCategoryAssignments");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.MenuCategoryAssignment", b =>
                {
                    b.HasOne("Ilies_Dragos_Restaurant.Models.MenuCategory", "MenuCategory")
                        .WithMany("MenuCategoryAssignments")
                        .HasForeignKey("MenuCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ilies_Dragos_Restaurant.Models.Menu", "Menu")
                        .WithMany("MenuCategoryAssignments")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("MenuCategory");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.MenuItem", b =>
                {
                    b.HasOne("Ilies_Dragos_Restaurant.Models.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuID");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.Restaurant", b =>
                {
                    b.HasOne("Ilies_Dragos_Restaurant.Models.Menu", "Menu")
                        .WithMany("Restaurants")
                        .HasForeignKey("MenuID");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.RestaurantCategoryAssignment", b =>
                {
                    b.HasOne("Ilies_Dragos_Restaurant.Models.RestaurantCategory", "RestaurantCategory")
                        .WithMany("RestaurantCategoryAssignments")
                        .HasForeignKey("RestaurantCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ilies_Dragos_Restaurant.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantCategoryAssignments")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("RestaurantCategory");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.Menu", b =>
                {
                    b.Navigation("MenuCategoryAssignments");

                    b.Navigation("MenuItems");

                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.MenuCategory", b =>
                {
                    b.Navigation("MenuCategoryAssignments");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.Restaurant", b =>
                {
                    b.Navigation("RestaurantCategoryAssignments");
                });

            modelBuilder.Entity("Ilies_Dragos_Restaurant.Models.RestaurantCategory", b =>
                {
                    b.Navigation("RestaurantCategoryAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
