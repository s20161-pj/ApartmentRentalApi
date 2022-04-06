﻿// <auto-generated />
using System;
using ApartmentRental.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApartmentRental.Infrastructure.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("ApartmentRental.Core.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAccountActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AparmentNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsElement")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LandlordId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("RentalAmount")
                        .HasColumnType("TEXT");

                    b.Property<int>("SquareMeters")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("LandlordId");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("Apartment");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Landlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Landlord");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Account", b =>
                {
                    b.HasOne("ApartmentRental.Core.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Apartment", b =>
                {
                    b.HasOne("ApartmentRental.Core.Entities.Address", "Adress")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApartmentRental.Core.Entities.Landlord", "Landlord")
                        .WithMany("Apartments")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApartmentRental.Core.Entities.Tenant", null)
                        .WithOne("Apartment")
                        .HasForeignKey("ApartmentRental.Core.Entities.Apartment", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");

                    b.Navigation("Landlord");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Image", b =>
                {
                    b.HasOne("ApartmentRental.Core.Entities.Apartment", "Apartment")
                        .WithMany("Images")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Landlord", b =>
                {
                    b.HasOne("ApartmentRental.Core.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Tenant", b =>
                {
                    b.HasOne("ApartmentRental.Core.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Apartment", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Landlord", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("ApartmentRental.Core.Entities.Tenant", b =>
                {
                    b.Navigation("Apartment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
