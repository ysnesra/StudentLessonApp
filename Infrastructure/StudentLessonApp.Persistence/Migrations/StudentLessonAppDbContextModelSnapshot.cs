﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentLessonApp.Persistence.Contexts;

#nullable disable

namespace StudentLessonApp.Persistence.Migrations
{
    [DbContext(typeof(StudentLessonAppDbContext))]
    partial class StudentLessonAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LessonStudent", b =>
                {
                    b.Property<Guid>("LessonsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("LessonsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("LessonStudent");
                });

            modelBuilder.Entity("StudentLessonApp.Domain.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22905372-470f-4b15-8876-f61b72691841"),
                            Description = "Java",
                            Name = "Programming languages1"
                        },
                        new
                        {
                            Id = new Guid("23905372-470f-4b15-8876-f61b72691842"),
                            Description = "C#",
                            Name = "Programming languages2"
                        },
                        new
                        {
                            Id = new Guid("24905372-470f-4b15-8876-f61b72691843"),
                            Description = "React Native and Flutter Frameworks",
                            Name = "Mobile App Development"
                        },
                        new
                        {
                            Id = new Guid("25905372-470f-4b15-8876-f61b72691843"),
                            Description = "MicroServices",
                            Name = "Software Architectures"
                        },
                        new
                        {
                            Id = new Guid("26905372-470f-4b15-8876-f61b72691843"),
                            Description = "Searching-Sorting Algorithms",
                            Name = "Data Structures and Algorithms"
                        });
                });

            modelBuilder.Entity("StudentLessonApp.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("72305372-470f-4b15-8876-f61b72691841"),
                            Email = "esra@gmail.com",
                            FullName = "Esra Yaşın",
                            Password = "Esra.1",
                            Phone = "05331545547",
                            UserName = "esra"
                        },
                        new
                        {
                            Id = new Guid("73305372-470f-4b15-8876-f61b72691843"),
                            Email = "mehmet@gmail.com",
                            FullName = "Mehmet Kutlu",
                            Password = "Mehmet.1",
                            Phone = "05551545547",
                            UserName = "mehmet"
                        });
                });

            modelBuilder.Entity("LessonStudent", b =>
                {
                    b.HasOne("StudentLessonApp.Domain.Entities.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentLessonApp.Domain.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
