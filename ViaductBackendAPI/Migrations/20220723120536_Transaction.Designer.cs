﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViaductBackendAPI.Models;

#nullable disable

namespace ViaductBackendAPI.Migrations
{
    [DbContext(typeof(ViaductDbContext))]
    [Migration("20220723120536_Transaction")]
    partial class Transaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ViaductBackendAPI.Models.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"), 1L, 1);

                    b.Property<decimal>("CardIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("ViaductBackendAPI.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("TransactionId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("ViaductBackendAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("BarRate")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryRate")
                        .HasColumnType("int");

                    b.Property<int>("KitchenRate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
