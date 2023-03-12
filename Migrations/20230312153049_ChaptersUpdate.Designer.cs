﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Primer_proyecto.DataAcces;

#nullable disable

namespace Primer_proyecto.Migrations
{
    [DbContext(typeof(UniversityDBContext))]
    [Migration("20230312153049_ChaptersUpdate")]
    partial class ChaptersUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryCurso", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("integer");

                    b.Property<int>("CursosId")
                        .HasColumnType("integer");

                    b.HasKey("CategoriesId", "CursosId");

                    b.HasIndex("CursosId");

                    b.ToTable("CategoryCurso");
                });

            modelBuilder.Entity("CursoStudent", b =>
                {
                    b.Property<int>("CursosId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentsId")
                        .HasColumnType("integer");

                    b.HasKey("CursosId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CursoStudent");
                });

            modelBuilder.Entity("Primer_proyecto.Models.DataModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleteBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Primer_proyecto.Models.DataModels.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CursoId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleteBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("List")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CursoId")
                        .IsUnique();

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Primer_proyecto.Models.DataModels.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleteBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("character varying(280)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("level")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Primer_proyecto.Models.DataModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleteBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Primer_proyecto.Models.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeleteBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CategoryCurso", b =>
                {
                    b.HasOne("Primer_proyecto.Models.DataModels.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Primer_proyecto.Models.DataModels.Curso", null)
                        .WithMany()
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CursoStudent", b =>
                {
                    b.HasOne("Primer_proyecto.Models.DataModels.Curso", null)
                        .WithMany()
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Primer_proyecto.Models.DataModels.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Primer_proyecto.Models.DataModels.Chapter", b =>
                {
                    b.HasOne("Primer_proyecto.Models.DataModels.Curso", "Curso")
                        .WithOne("Chapters")
                        .HasForeignKey("Primer_proyecto.Models.DataModels.Chapter", "CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Primer_proyecto.Models.DataModels.Curso", b =>
                {
                    b.Navigation("Chapters")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
