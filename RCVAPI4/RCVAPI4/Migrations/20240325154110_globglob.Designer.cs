﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCVAPI4.Data;

#nullable disable

namespace RCVAPI4.Migrations
{
    [DbContext(typeof(ClothesAPIDbContext))]
    [Migration("20240325154110_globglob")]
    partial class globglob
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RCVAPI4.Models.ClotheFolder.Clothe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("clothe_color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clothe_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clothe_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clothe_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clothe_price")
                        .HasColumnType("int");

                    b.Property<string>("clothe_size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clothe_textile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clothe_type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clothes");
                });

            modelBuilder.Entity("RCVAPI4.Models.TicketsFolder.TicketC", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ticket_acceptUserId")
                        .HasColumnType("int");

                    b.Property<string>("ticket_contactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ticket_createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ticket_deliveryAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ticket_deliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ticket_deliveryStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticket_productsId")
                        .HasColumnType("int");

                    b.Property<int>("ticket_sum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TicketsT");
                });

            modelBuilder.Entity("RCVAPI4.Models.UserFolder.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("user_city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
