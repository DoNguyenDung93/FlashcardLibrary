﻿// <auto-generated />
using System;
using FlashcardLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlashcardLibrary.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlashcardLibrary.Data.Category", b =>
                {
                    b.Property<Guid>("ObjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObjectID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Flashcard", b =>
                {
                    b.Property<Guid>("ObjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryObjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObjectID");

                    b.HasIndex("CategoryObjectID");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Flashcard", b =>
                {
                    b.HasOne("FlashcardLibrary.Data.Category", null)
                        .WithMany("Flashcards")
                        .HasForeignKey("CategoryObjectID");
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Category", b =>
                {
                    b.Navigation("Flashcards");
                });
#pragma warning restore 612, 618
        }
    }
}