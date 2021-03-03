﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewPostgresApp;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NewPostgresApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210303132038_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NewPostgresApp.Posts", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnName("Content")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("WriterId")
                        .HasColumnName("WriterId")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("WriterId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            ID = new Guid("b72dcaf0-0769-4693-903d-dd76025e4ec3"),
                            Content = "111",
                            Name = "First post",
                            WriterId = new Guid("15a96f15-5ebb-4764-8213-11dce2002ef5")
                        },
                        new
                        {
                            ID = new Guid("ffad56dc-4f39-4bf2-b85a-d766c06cf7a8"),
                            Content = "222",
                            Name = "Second post",
                            WriterId = new Guid("15a96f15-5ebb-4764-8213-11dce2002ef5")
                        },
                        new
                        {
                            ID = new Guid("a32dfd24-03de-40de-bd77-ae04e0442561"),
                            Content = "333",
                            Name = "Third post",
                            WriterId = new Guid("15a96f15-5ebb-4764-8213-11dce2002ef5")
                        },
                        new
                        {
                            ID = new Guid("b89989ae-9d08-49f8-a447-437bc496f694"),
                            Content = "444",
                            Name = "Fourth post",
                            WriterId = new Guid("630e64fc-2334-468b-af6d-d08d753af05e")
                        },
                        new
                        {
                            ID = new Guid("c7cfbb47-8712-4588-aee2-cd51be2bc166"),
                            Content = "555",
                            Name = "Fifth post",
                            WriterId = new Guid("630e64fc-2334-468b-af6d-d08d753af05e")
                        },
                        new
                        {
                            ID = new Guid("2f0763e0-f94b-492b-a516-6bb958a1fc65"),
                            Content = "6*6",
                            Name = "Sixth post",
                            WriterId = new Guid("630e64fc-2334-468b-af6d-d08d753af05e")
                        },
                        new
                        {
                            ID = new Guid("e043c690-1a3b-4391-8cb3-bfb7aee97c6f"),
                            Content = "777",
                            Name = "Seventh post",
                            WriterId = new Guid("25e5551c-529b-4d81-9ded-fbda38a1f039")
                        },
                        new
                        {
                            ID = new Guid("1c9ddf72-ca59-4a0e-ac55-4d1385fa3c98"),
                            Content = "888",
                            Name = "Eighth post",
                            WriterId = new Guid("25e5551c-529b-4d81-9ded-fbda38a1f039")
                        },
                        new
                        {
                            ID = new Guid("1bbcc368-7c27-4e2c-a9dd-36c1d7f0bf7a"),
                            Content = "999",
                            Name = "Ninth post",
                            WriterId = new Guid("25e5551c-529b-4d81-9ded-fbda38a1f039")
                        });
                });

            modelBuilder.Entity("NewPostgresApp.Writers", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.HasKey("ID");

                    b.ToTable("Writers");

                    b.HasData(
                        new
                        {
                            ID = new Guid("15a96f15-5ebb-4764-8213-11dce2002ef5"),
                            Name = "Adam"
                        },
                        new
                        {
                            ID = new Guid("630e64fc-2334-468b-af6d-d08d753af05e"),
                            Name = "Bob"
                        },
                        new
                        {
                            ID = new Guid("25e5551c-529b-4d81-9ded-fbda38a1f039"),
                            Name = "Charlie"
                        });
                });

            modelBuilder.Entity("NewPostgresApp.Posts", b =>
                {
                    b.HasOne("NewPostgresApp.Writers", "Writer")
                        .WithMany("Posted")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
