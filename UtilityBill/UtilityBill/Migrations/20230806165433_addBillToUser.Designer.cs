﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UtilityBill.Data;

#nullable disable

namespace UtilityBill.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230806165433_addBillToUser")]
    partial class addBillToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UtilityBill.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PinCode")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("UtilityBill.ApplicationDetail", b =>
                {
                    b.Property<int>("ApplicationDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationDetailId"));

                    b.Property<DateTime?>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MeterDetailMeterId")
                        .HasColumnType("int");

                    b.Property<string>("RequiredLoad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationDetailId");

                    b.HasIndex("MeterDetailMeterId");

                    b.ToTable("ApplicationDetail");
                });

            modelBuilder.Entity("UtilityBill.BillDetail", b =>
                {
                    b.Property<int>("BillDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillDetailId"));

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BillStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MeterDetailMeterId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsConsumed")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BillDetailId");

                    b.HasIndex("MeterDetailMeterId");

                    b.HasIndex("UserId");

                    b.ToTable("BillDetail");
                });

            modelBuilder.Entity("UtilityBill.MeterDetail", b =>
                {
                    b.Property<int>("MeterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeterId"));

                    b.Property<DateTime>("InstallationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeterId");

                    b.ToTable("MeterDetail");
                });

            modelBuilder.Entity("UtilityBill.TicketDetail", b =>
                {
                    b.Property<int>("TicketDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketDetailId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketDetailId");

                    b.HasIndex("UserId");

                    b.ToTable("TicketDetail");
                });

            modelBuilder.Entity("UtilityBill.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicationDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.HasIndex("ApplicationDetailId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("UtilityBill.ApplicationDetail", b =>
                {
                    b.HasOne("UtilityBill.MeterDetail", "MeterDetail")
                        .WithMany()
                        .HasForeignKey("MeterDetailMeterId");

                    b.Navigation("MeterDetail");
                });

            modelBuilder.Entity("UtilityBill.BillDetail", b =>
                {
                    b.HasOne("UtilityBill.MeterDetail", "MeterDetail")
                        .WithMany("BillDetail")
                        .HasForeignKey("MeterDetailMeterId");

                    b.HasOne("UtilityBill.User", null)
                        .WithMany("BillDetails")
                        .HasForeignKey("UserId");

                    b.Navigation("MeterDetail");
                });

            modelBuilder.Entity("UtilityBill.TicketDetail", b =>
                {
                    b.HasOne("UtilityBill.User", "User")
                        .WithMany("TicketDetail")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UtilityBill.User", b =>
                {
                    b.HasOne("UtilityBill.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("UtilityBill.ApplicationDetail", "ApplicationDetail")
                        .WithMany()
                        .HasForeignKey("ApplicationDetailId");

                    b.Navigation("Address");

                    b.Navigation("ApplicationDetail");
                });

            modelBuilder.Entity("UtilityBill.MeterDetail", b =>
                {
                    b.Navigation("BillDetail");
                });

            modelBuilder.Entity("UtilityBill.User", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("TicketDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
