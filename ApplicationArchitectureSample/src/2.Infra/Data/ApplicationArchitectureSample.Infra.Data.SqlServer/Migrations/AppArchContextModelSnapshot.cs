﻿// <auto-generated />
using System;
using ApplicationArchitectureSample.Infra.Data.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationArchitectureSample.Infra.Data.SqlServer.Migrations
{
    [DbContext(typeof(AppArchContext))]
    partial class AppArchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationArchitectureSample.Core.Domain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ApplicationArchitectureSample.Core.Domain.PhoneNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("ApplicationArchitectureSample.Core.Domain.PhoneNumber", b =>
                {
                    b.HasOne("ApplicationArchitectureSample.Core.Domain.Person", null)
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("ApplicationArchitectureSample.Core.Domain.Person", b =>
                {
                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
