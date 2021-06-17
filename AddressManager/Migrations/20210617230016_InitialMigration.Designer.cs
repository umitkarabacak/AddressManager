﻿// <auto-generated />
using System;
using AddressManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AddressManager.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20210617230016_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddressManager.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AddressManager.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AddressManager.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlphaCode2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlphaCode3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumericCode")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumberCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AddressManager.Models.District", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DistrictCode")
                        .HasColumnType("int");

                    b.Property<int>("DistrictDescription")
                        .HasColumnType("int");

                    b.Property<int>("DistrictName")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("AddressManager.Models.Address", b =>
                {
                    b.HasOne("AddressManager.Models.District", "District")
                        .WithMany("Addresses")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("AddressManager.Models.City", b =>
                {
                    b.HasOne("AddressManager.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AddressManager.Models.District", b =>
                {
                    b.HasOne("AddressManager.Models.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("AddressManager.Models.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("AddressManager.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("AddressManager.Models.District", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
