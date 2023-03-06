﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SuperHeroes.Domain;

#nullable disable

namespace SuperHeroes.Domain.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SuperHeroes.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("SuperHeroes.Domain.Entities.CategoryPerson", b =>
                {
                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("person_id");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("PersonId", "CategoryId")
                        .HasName("pk_category_person");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_category_person_category_id");

                    b.ToTable("category_person", (string)null);
                });

            modelBuilder.Entity("SuperHeroes.Domain.Entities.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("SuperHeroName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("super_hero_name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_person");

                    b.ToTable("person", (string)null);
                });

            modelBuilder.Entity("SuperHeroes.Domain.Entities.CategoryPerson", b =>
                {
                    b.HasOne("SuperHeroes.Domain.Entities.Category", "Category")
                        .WithMany("CategoryPersons")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_category_person_categories_category_id");

                    b.HasOne("SuperHeroes.Domain.Entities.Person", "Person")
                        .WithMany("CategoryPersons")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_category_person_person_person_id");

                    b.Navigation("Category");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SuperHeroes.Domain.Entities.Category", b =>
                {
                    b.Navigation("CategoryPersons");
                });

            modelBuilder.Entity("SuperHeroes.Domain.Entities.Person", b =>
                {
                    b.Navigation("CategoryPersons");
                });
#pragma warning restore 612, 618
        }
    }
}
