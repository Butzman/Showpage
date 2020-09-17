﻿// <auto-generated />
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dal.Data.Migrations
{
    [DbContext(typeof(DalContext))]
    partial class DalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = "3d005a35-a852-4a16-a4da-bea5d9886734",
                            EAN = "305190653",
                            Name = "Vr Glasses"
                        },
                        new
                        {
                            Id = "dcf83ad5-1d99-4568-9b56-c5aac9673131",
                            EAN = "305716906",
                            Name = "Keyboard"
                        },
                        new
                        {
                            Id = "02573f26-1472-42dc-9a5e-9692cedc988f",
                            EAN = "975588959",
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = "b81f326c-4288-4f8d-a102-8a1fa31187e1",
                            EAN = "742652122",
                            Name = "Ventilator"
                        },
                        new
                        {
                            Id = "3bafc2d1-8179-476a-b1ab-1e18abf945fb",
                            EAN = "019358550",
                            Name = "Charger"
                        },
                        new
                        {
                            Id = "e90b854a-2bcd-4152-8e96-766c240c6126",
                            EAN = "668631386",
                            Name = "Cup"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
