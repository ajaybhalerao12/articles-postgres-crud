﻿// <auto-generated />
using System;
using ArticlesPOSTGREDBCRUDOperations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArticlesPOSTGREDBCRUDOperations.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240827144645_Authors_Categories")]
    partial class Authors_Categories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 0,
                            Content = "This is the content of the first article.",
                            CreatedAt = new DateTime(2024, 8, 27, 14, 46, 45, 387, DateTimeKind.Utc).AddTicks(7766),
                            Title = "First Article"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 0,
                            Content = "This is the content of the second article.",
                            CreatedAt = new DateTime(2024, 8, 27, 14, 46, 45, 387, DateTimeKind.Utc).AddTicks(7778),
                            Title = "Second Article"
                        });
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.ArticleCategory", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("ArticleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "$2a$11$2MjIacEN/1sj1MFCGA5l9O4FQlCCJ2.u36qmxOtwCjgGoB6L.cISC",
                            UserName = "test"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = "$2a$11$c98hsyM4QLuDiCEMjvlbWOuZAn8i09Ct3THRD23wyvhr.I6/v6ex6",
                            UserName = "test2"
                        });
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.Article", b =>
                {
                    b.HasOne("ArticlesPOSTGREDBCRUDOperations.Models.Author", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.ArticleCategory", b =>
                {
                    b.HasOne("ArticlesPOSTGREDBCRUDOperations.Models.Article", "Article")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArticlesPOSTGREDBCRUDOperations.Models.Category", "Category")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.Article", b =>
                {
                    b.Navigation("ArticleCategories");
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.Author", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("ArticlesPOSTGREDBCRUDOperations.Models.Category", b =>
                {
                    b.Navigation("ArticleCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
