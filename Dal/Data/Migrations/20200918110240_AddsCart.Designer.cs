﻿// <auto-generated />
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dal.Data.Migrations
{
    [DbContext(typeof(DalContext))]
    [Migration("20200918110240_AddsCart")]
    partial class AddsCart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Dal.Entities.ProductEntity", b =>
                {
                    b.Property<string>("Id")
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
                            EAN = "099603759",
                            Name = "Vr Glasses"
                        },
                        new
                        {
                            Id = "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                            EAN = "417303535",
                            Name = "Keyboard"
                        },
                        new
                        {
                            Id = "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                            EAN = "428294030",
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                            EAN = "544671531",
                            Name = "Ventilator"
                        },
                        new
                        {
                            Id = "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                            EAN = "580552543",
                            Name = "Charger"
                        },
                        new
                        {
                            Id = "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                            EAN = "077770322",
                            Name = "Cup"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}