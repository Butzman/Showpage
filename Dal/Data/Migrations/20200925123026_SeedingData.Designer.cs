﻿// <auto-generated />
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dal.Data.Migrations
{
    [DbContext(typeof(DalContext))]
    [Migration("20200925123026_SeedingData")]
    partial class SeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Dal.Entities.CartEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = "4b760d44-10eb-4596-9d6f-da45e4e9a228",
                            Name = "First Cart",
                            UserId = "a7b420a1-66cc-42b3-8bc0-5bc3abf39850"
                        },
                        new
                        {
                            Id = "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                            Name = "Second Cart",
                            UserId = "a7b420a1-66cc-42b3-8bc0-5bc3abf39850"
                        });
                });

            modelBuilder.Entity("Dal.Entities.ProductEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EAN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                            Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.",
                            EAN = "544388910",
                            Name = "Vr Glasses"
                        },
                        new
                        {
                            Id = "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                            Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.",
                            EAN = "195654221",
                            Name = "Keyboard"
                        },
                        new
                        {
                            Id = "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                            Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.",
                            EAN = "094139697",
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                            Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.",
                            EAN = "926004429",
                            Name = "Ventilator"
                        },
                        new
                        {
                            Id = "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                            Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.",
                            EAN = "698472040",
                            Name = "Charger"
                        },
                        new
                        {
                            Id = "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                            Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.",
                            EAN = "391356246",
                            Name = "Cup"
                        });
                });

            modelBuilder.Entity("Dal.Entities.ProductToCartEntity", b =>
                {
                    b.Property<string>("CartId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductToCartEntity");

                    b.HasData(
                        new
                        {
                            CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 2
                        },
                        new
                        {
                            CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 2
                        },
                        new
                        {
                            CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 4
                        },
                        new
                        {
                            CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 2
                        },
                        new
                        {
                            CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 4
                        },
                        new
                        {
                            CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 5
                        },
                        new
                        {
                            CartId = "4b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 6
                        },
                        new
                        {
                            CartId = "4b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 1
                        },
                        new
                        {
                            CartId = "4b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 4
                        },
                        new
                        {
                            CartId = "4b760d44-10eb-4596-9d6f-da45e4e9a228",
                            ProductId = "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                            Amount = 3
                        });
                });

            modelBuilder.Entity("Dal.Entities.ProductToCartEntity", b =>
                {
                    b.HasOne("Dal.Entities.CartEntity", "CartEntity")
                        .WithMany("Products")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Entities.ProductEntity", "ProductEntity")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
