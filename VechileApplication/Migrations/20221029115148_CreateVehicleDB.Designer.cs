﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VechileApplication.Models;

#nullable disable

namespace VechileApplication.Migrations
{
    [DbContext(typeof(vehicleDbContext))]
    [Migration("20221029115148_CreateVehicleDB")]
    partial class CreateVehicleDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VechileApplication.Models.Make", b =>
                {
                    b.Property<int>("make_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("make_id"), 1L, 1);

                    b.Property<string>("make_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("make_id");

                    b.ToTable("Make");
                });

            modelBuilder.Entity("VechileApplication.Models.Model", b =>
                {
                    b.Property<int>("model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("model_id"), 1L, 1);

                    b.Property<int>("make_id")
                        .HasColumnType("int");

                    b.Property<string>("model_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("model_id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("VechileApplication.Models.Price", b =>
                {
                    b.Property<int>("price_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("price_id"), 1L, 1);

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("v_id")
                        .HasColumnType("int");

                    b.HasKey("price_id");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("VechileApplication.Models.Vehicles", b =>
                {
                    b.Property<int>("v_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("v_id"), 1L, 1);

                    b.Property<int>("make_id")
                        .HasColumnType("int");

                    b.Property<int>("model_id")
                        .HasColumnType("int");

                    b.Property<string>("v_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("v_id");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}