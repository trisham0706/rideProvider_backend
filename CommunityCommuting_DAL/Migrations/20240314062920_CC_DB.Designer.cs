﻿// <auto-generated />
using System;
using CommunityCommuting_DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CommunityCommuting_DAL.Migrations
{
    [DbContext(typeof(CommunityCommutingDbContext))]
    [Migration("20240314062920_CC_DB")]
    partial class CC_DB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommunityCommuting_DAL.Models.RideInfo", b =>
                {
                    b.Property<string>("vehicleNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("carName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("noOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("rpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("vehicleNo");

                    b.HasIndex("rpId");

                    b.ToTable("RideInfos");
                });

            modelBuilder.Entity("CommunityCommuting_DAL.Models.RideProvide", b =>
                {
                    b.Property<string>("rpId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("adharcard")
                        .HasMaxLength(12)
                        .HasColumnType("int")
                        .HasAnnotation("MinLength", 12);

                    b.Property<string>("dlNo")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nchar(16)")
                        .IsFixedLength()
                        .HasAnnotation("RegexPattern", "^[A-Z0-9]{2}-[A-Z0-9]{2}-[A-Z0-9]{8}$");

                    b.Property<string>("emailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasAnnotation("AllowedValues", new[] { "Registered", "Un-registered" });

                    b.Property<DateOnly>("validUpto")
                        .HasColumnType("date")
                        .HasAnnotation("MinValue", new DateTime(2024, 4, 13, 11, 59, 19, 612, DateTimeKind.Local).AddTicks(6193));

                    b.HasKey("rpId");

                    b.ToTable("RideProvides");
                });

            modelBuilder.Entity("CommunityCommuting_DAL.Models.Smile", b =>
                {
                    b.Property<int>("smileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("smileId"));

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("occupancy")
                        .HasColumnType("int");

                    b.Property<string>("rpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("smileId");

                    b.HasIndex("rpId");

                    b.ToTable("Smiles");
                });

            modelBuilder.Entity("CommunityCommuting_DAL.Models.RideInfo", b =>
                {
                    b.HasOne("CommunityCommuting_DAL.Models.RideProvide", "rideProvide")
                        .WithMany("RideInfos")
                        .HasForeignKey("rpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rideProvide");
                });

            modelBuilder.Entity("CommunityCommuting_DAL.Models.Smile", b =>
                {
                    b.HasOne("CommunityCommuting_DAL.Models.RideInfo", "rideInfo")
                        .WithMany("Smiles")
                        .HasForeignKey("rpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rideInfo");
                });

            modelBuilder.Entity("CommunityCommuting_DAL.Models.RideInfo", b =>
                {
                    b.Navigation("Smiles");
                });

            modelBuilder.Entity("CommunityCommuting_DAL.Models.RideProvide", b =>
                {
                    b.Navigation("RideInfos");
                });
#pragma warning restore 612, 618
        }
    }
}