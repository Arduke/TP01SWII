﻿// <auto-generated />
using System;
using EFGetStarted;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFGetStarted.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("EFGetStarted.Model.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("bookId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<char>("gender")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.HasIndex("bookId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("EFGetStarted.Model.Book", b =>
                {
                    b.Property<int>("bookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<double>("price")
                        .HasColumnType("REAL");

                    b.Property<int>("qty")
                        .HasColumnType("INTEGER");

                    b.HasKey("bookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EFGetStarted.Model.Author", b =>
                {
                    b.HasOne("EFGetStarted.Model.Book", null)
                        .WithMany("authors")
                        .HasForeignKey("bookId");
                });
#pragma warning restore 612, 618
        }
    }
}