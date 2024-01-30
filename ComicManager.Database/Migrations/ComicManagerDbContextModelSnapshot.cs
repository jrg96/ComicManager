﻿// <auto-generated />
using System;
using ComicManager.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComicManager.Database.Migrations
{
    [DbContext(typeof(ComicManagerDbContext))]
    partial class ComicManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComicManager.Database.Entity.Character", b =>
                {
                    b.Property<Guid>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("ComicManager.Database.Entity.CharacterComic", b =>
                {
                    b.Property<Guid>("CharacterComicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CharacterComicId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ComicId");

                    b.ToTable("CharacterComics");
                });

            modelBuilder.Entity("ComicManager.Database.Entity.Comic", b =>
                {
                    b.Property<Guid>("ComicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ComicId");

                    b.ToTable("Comics");
                });

            modelBuilder.Entity("ComicManager.Database.Entity.CharacterComic", b =>
                {
                    b.HasOne("ComicManager.Database.Entity.Character", "Character")
                        .WithMany("CharacterComics")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicManager.Database.Entity.Comic", "Comic")
                        .WithMany("CharacterComics")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("ComicManager.Database.Entity.Character", b =>
                {
                    b.Navigation("CharacterComics");
                });

            modelBuilder.Entity("ComicManager.Database.Entity.Comic", b =>
                {
                    b.Navigation("CharacterComics");
                });
#pragma warning restore 612, 618
        }
    }
}
