﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sipay_Final.DataAccess.Context;

#nullable disable

namespace Sipay_Final.DataAccess.Migrations
{
    [DbContext(typeof(FinalDbContext))]
    partial class FinalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastActivity")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "admin@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6072),
                            Email = "admin@gmail.com",
                            Firstname = "admin",
                            IsActive = true,
                            Lastname = "admin",
                            Password = "Lkxdh-(q)Pv+",
                            Role = 1
                        });
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<int>("Block")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Resident")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Apartments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApartmentNumber = 4,
                            Block = 1,
                            CreatedBy = "admin@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6270),
                            Floor = 2,
                            IsActive = true,
                            Resident = 2,
                            Status = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 2,
                            ApartmentNumber = 2,
                            Block = 2,
                            CreatedBy = "admin@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6273),
                            Floor = 1,
                            IsActive = true,
                            Resident = 2,
                            Status = 1,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.MessageToAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("UserId");

                    b.ToTable("MessageToAdmins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            CreatedBy = "johndoe@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6300),
                            IsActive = true,
                            Status = 2,
                            Text = "Hi,Our water pipe burst. Could you direct me to the plumber? ",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.MessageToUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("UserId");

                    b.ToTable("MessageToUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            CreatedBy = "admin@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6308),
                            IsActive = true,
                            Status = 1,
                            Text = "Hi,please pay your bill.",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.PayInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BillDuesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Dues")
                        .HasPrecision(2)
                        .HasColumnType("int");

                    b.Property<int?>("ElectricityBill")
                        .HasPrecision(2)
                        .HasColumnType("int");

                    b.Property<int?>("GasBill")
                        .HasPrecision(2)
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WaterBill")
                        .HasPrecision(2)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("PayInformations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApartmentId = 2,
                            BillDuesDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6286),
                            CreatedBy = "admin@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6289),
                            Dues = 250,
                            ElectricityBill = 200,
                            GasBill = 800,
                            IsActive = true,
                            WaterBill = 150
                        },
                        new
                        {
                            Id = 2,
                            ApartmentId = 1,
                            BillDuesDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6291),
                            CreatedBy = "admin@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6291),
                            Dues = 300,
                            ElectricityBill = 150,
                            GasBill = 600,
                            IsActive = true,
                            WaterBill = 200
                        });
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ApartmentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastActivity")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("LicensePlate")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Tc")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApartmentId = 1,
                            CreatedBy = "admin@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6187),
                            Email = "johndoe@gmail.com",
                            Firstname = "John",
                            IsActive = true,
                            Lastname = "Doe",
                            LicensePlate = "34BY428",
                            Password = "Omdk_2j50Nud",
                            Phone = "05342569312",
                            Role = 0,
                            Tc = "23674356974"
                        },
                        new
                        {
                            Id = 2,
                            ApartmentId = 2,
                            CreatedBy = "admin@gmail.com",
                            CreatedDate = new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6198),
                            Email = "jeyndoe@gmail.com",
                            Firstname = "Jeyn",
                            IsActive = true,
                            Lastname = "Doe",
                            Password = "x&w%p10B4ww0",
                            Phone = "05317241735",
                            Role = 0,
                            Tc = "45832173821"
                        });
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.MessageToAdmin", b =>
                {
                    b.HasOne("Sipay_Final.Entities.DbSets.Admin", "Admin")
                        .WithMany("IncomingToAdmin")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sipay_Final.Entities.DbSets.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.MessageToUser", b =>
                {
                    b.HasOne("Sipay_Final.Entities.DbSets.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sipay_Final.Entities.DbSets.User", "User")
                        .WithMany("IncomingToUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.PayInformation", b =>
                {
                    b.HasOne("Sipay_Final.Entities.DbSets.Apartment", "Apartment")
                        .WithMany("PayInformations")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.User", b =>
                {
                    b.HasOne("Sipay_Final.Entities.DbSets.Apartment", "Apartment")
                        .WithOne("User")
                        .HasForeignKey("Sipay_Final.Entities.DbSets.User", "ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.Admin", b =>
                {
                    b.Navigation("IncomingToAdmin");
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.Apartment", b =>
                {
                    b.Navigation("PayInformations");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sipay_Final.Entities.DbSets.User", b =>
                {
                    b.Navigation("IncomingToUser");
                });
#pragma warning restore 612, 618
        }
    }
}
