﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValueObjects.EfSamples;

#nullable disable

namespace ValueObjects.EfSamples.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20231207185133_init")]
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

            modelBuilder.Entity("ValueObjects.EfSamples.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ValueObjects.EfSamples.Person", b =>
                {
                    b.OwnsOne("ValueObjects.EfSamples.FirstName", "FirstName", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId");

                            b1.ToTable("People");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("FirstName")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}