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
    [Migration("20240826144835_UserTableColumnNotNullable")]
    partial class UserTableColumnNotNullable
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

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is the content of the first article.",
                            CreatedAt = new DateTime(2024, 8, 26, 14, 48, 35, 130, DateTimeKind.Utc).AddTicks(3093),
                            Title = "First Article"
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is the content of the second article.",
                            CreatedAt = new DateTime(2024, 8, 26, 14, 48, 35, 130, DateTimeKind.Utc).AddTicks(3098),
                            Title = "Second Article"
                        });
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
                            PasswordHash = "$2a$11$rihoS60h2FSl/Sta/LwYluV7hauS/ggMuvCnvUmCeWOnbUL1zul2W",
                            UserName = "test"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = "$2a$11$.IN/CpWTdzh..aMQNBhIvOb/NHp1C9bI/5kmf6msfV9VSJPMq79IS",
                            UserName = "test2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
