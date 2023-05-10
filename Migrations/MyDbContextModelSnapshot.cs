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
    [DbContext(typeof(FlashcardContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlashcardLibrary.Data.Attachment", b =>
                {
                    b.Property<Guid>("ObjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AttachmentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FlashcardID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlashcardObjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlashcardObjectID1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlashcardObjectID2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlashcardObjectID3")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlashcardObjectID4")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ObjectID");

                    b.HasIndex("FlashcardID");

                    b.HasIndex("FlashcardObjectID");

                    b.HasIndex("FlashcardObjectID1");

                    b.HasIndex("FlashcardObjectID2");

                    b.HasIndex("FlashcardObjectID3");

                    b.HasIndex("FlashcardObjectID4");

                    b.ToTable("Attachment", (string)null);
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Category", b =>
                {
                    b.Property<Guid>("ObjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ObjectID");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Flashcard", b =>
                {
                    b.Property<Guid>("ObjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ObjectID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Flashcard", (string)null);
                });

            modelBuilder.Entity("FlashcardLibrary.Data.User", b =>
                {
                    b.Property<Guid>("ObjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ObjectID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Attachment", b =>
                {
                    b.HasOne("FlashcardLibrary.Data.Flashcard", "Flashcard")
                        .WithMany("Attachments")
                        .HasForeignKey("FlashcardID");

                    b.HasOne("FlashcardLibrary.Data.Flashcard", null)
                        .WithMany("Antonyms")
                        .HasForeignKey("FlashcardObjectID");

                    b.HasOne("FlashcardLibrary.Data.Flashcard", null)
                        .WithMany("Examples")
                        .HasForeignKey("FlashcardObjectID1");

                    b.HasOne("FlashcardLibrary.Data.Flashcard", null)
                        .WithMany("Meanings")
                        .HasForeignKey("FlashcardObjectID2");

                    b.HasOne("FlashcardLibrary.Data.Flashcard", null)
                        .WithMany("Pronunciations")
                        .HasForeignKey("FlashcardObjectID3");

                    b.HasOne("FlashcardLibrary.Data.Flashcard", null)
                        .WithMany("Synonyms")
                        .HasForeignKey("FlashcardObjectID4");

                    b.Navigation("Flashcard");
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Flashcard", b =>
                {
                    b.HasOne("FlashcardLibrary.Data.Category", "Category")
                        .WithMany("Flashcards")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Category", b =>
                {
                    b.Navigation("Flashcards");
                });

            modelBuilder.Entity("FlashcardLibrary.Data.Flashcard", b =>
                {
                    b.Navigation("Antonyms");

                    b.Navigation("Attachments");

                    b.Navigation("Examples");

                    b.Navigation("Meanings");

                    b.Navigation("Pronunciations");

                    b.Navigation("Synonyms");
                });
#pragma warning restore 612, 618
        }
    }
}
