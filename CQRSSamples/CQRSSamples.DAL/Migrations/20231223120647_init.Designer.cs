﻿// <auto-generated />
using System;
using CQRSSamples.Command.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CQRSSamples.DAL.Migrations
{
    [DbContext(typeof(RepoSampleCommandDbContext))]
    [Migration("20231223120647_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CQRSSamples.Domain.Categories.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CQRSSamples.Domain.Products.Entities.Discount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("CQRSSamples.Domain.Products.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CQRSSamples.Framework.OutBoxEventItem", b =>
                {
                    b.Property<long>("OutBoxEventItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OutBoxEventItemID"));

                    b.Property<string>("AccuredByUserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AccuredOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("AggregateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AggregateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AggregateTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventPayLoad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("bit");

                    b.HasKey("OutBoxEventItemID");

                    b.ToTable("OutBoxEventItems");
                });

            modelBuilder.Entity("CQRSSamples.Domain.Products.Entities.Discount", b =>
                {
                    b.HasOne("CQRSSamples.Domain.Products.Entities.Product", null)
                        .WithMany("Discounts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("CQRSSamples.Domain.Products.Entities.Product", b =>
                {
                    b.Navigation("Discounts");
                });
#pragma warning restore 612, 618
        }
    }
}