﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hight_school_follow_up.Properties.Data;

#nullable disable

namespace hight_school_follow_up.Migrations
{
    [DbContext(typeof(AppDBcontext))]
    [Migration("20231222134304_tahaaaa")]
    partial class tahaaaa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hight_school_follow_up.Models.Course", b =>
                {
                    b.Property<int>("courseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courseid"));

                    b.Property<string>("coursename")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("courseid");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.Grade", b =>
                {
                    b.Property<int>("gradeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("gradeid"));

                    b.Property<int>("grade")
                        .HasColumnType("int");

                    b.HasKey("gradeid");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.Parent", b =>
                {
                    b.Property<int>("parentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("parentid"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("parentimage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("parentname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("parentid");

                    b.ToTable("Parents", t =>
                        {
                            t.HasCheckConstraint("CK_ParentName_LettersAndSpaces", "[ParentName] LIKE '%[a-zA-Z ]%'");
                        });
                });

            modelBuilder.Entity("hight_school_follow_up.Models.Student", b =>
                {
                    b.Property<int>("studentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentid"));

                    b.Property<string>("behaviour")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("level")
                        .HasColumnType("int");

                    b.Property<string>("studentname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("studentid");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.StudentCourseGrade", b =>
                {
                    b.Property<int>("studentcoursegradeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentcoursegradeid"));

                    b.Property<int>("courseid")
                        .HasColumnType("int");

                    b.Property<int>("gradeid")
                        .HasColumnType("int");

                    b.Property<int>("studentid")
                        .HasColumnType("int");

                    b.HasKey("studentcoursegradeid");

                    b.HasIndex("courseid");

                    b.HasIndex("gradeid");

                    b.HasIndex("studentid");

                    b.ToTable("StudentCourseGrades");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.StudentParent", b =>
                {
                    b.Property<int>("studentparentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentparentid"));

                    b.Property<int>("parentid")
                        .HasColumnType("int");

                    b.Property<int?>("parentid1")
                        .HasColumnType("int");

                    b.Property<int>("studentid")
                        .HasColumnType("int");

                    b.Property<int?>("studentid1")
                        .HasColumnType("int");

                    b.HasKey("studentparentid");

                    b.HasIndex("parentid");

                    b.HasIndex("parentid1");

                    b.HasIndex("studentid");

                    b.HasIndex("studentid1");

                    b.ToTable("StudentParents");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.TeacherCourse", b =>
                {
                    b.Property<int>("teachercourseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("teachercourseid"));

                    b.Property<int>("courseid")
                        .HasColumnType("int");

                    b.Property<int?>("courseid1")
                        .HasColumnType("int");

                    b.Property<int>("teacherid")
                        .HasColumnType("int");

                    b.Property<int?>("teacherid1")
                        .HasColumnType("int");

                    b.HasKey("teachercourseid");

                    b.HasIndex("courseid");

                    b.HasIndex("courseid1");

                    b.HasIndex("teacherid");

                    b.HasIndex("teacherid1");

                    b.ToTable("TeacherCourses");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.teacher", b =>
                {
                    b.Property<int>("teacherid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("teacherid"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("teachername")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("teacherid");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.StudentCourseGrade", b =>
                {
                    b.HasOne("hight_school_follow_up.Models.Course", "course")
                        .WithMany("studentcoursegrades")
                        .HasForeignKey("courseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hight_school_follow_up.Models.Grade", "grade")
                        .WithMany()
                        .HasForeignKey("gradeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hight_school_follow_up.Models.Student", "student")
                        .WithMany("studentcoursegrades")
                        .HasForeignKey("studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("grade");

                    b.Navigation("student");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.StudentParent", b =>
                {
                    b.HasOne("hight_school_follow_up.Models.Parent", "parent")
                        .WithMany()
                        .HasForeignKey("parentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hight_school_follow_up.Models.Parent", null)
                        .WithMany("studentparents")
                        .HasForeignKey("parentid1");

                    b.HasOne("hight_school_follow_up.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hight_school_follow_up.Models.Student", null)
                        .WithMany("studentparents")
                        .HasForeignKey("studentid1");

                    b.Navigation("Student");

                    b.Navigation("parent");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.TeacherCourse", b =>
                {
                    b.HasOne("hight_school_follow_up.Models.Course", "course")
                        .WithMany()
                        .HasForeignKey("courseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hight_school_follow_up.Models.Course", null)
                        .WithMany("teachercourses")
                        .HasForeignKey("courseid1");

                    b.HasOne("hight_school_follow_up.Models.teacher", "teacher")
                        .WithMany()
                        .HasForeignKey("teacherid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hight_school_follow_up.Models.teacher", null)
                        .WithMany("teachercourses")
                        .HasForeignKey("teacherid1");

                    b.Navigation("course");

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.Course", b =>
                {
                    b.Navigation("studentcoursegrades");

                    b.Navigation("teachercourses");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.Parent", b =>
                {
                    b.Navigation("studentparents");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.Student", b =>
                {
                    b.Navigation("studentcoursegrades");

                    b.Navigation("studentparents");
                });

            modelBuilder.Entity("hight_school_follow_up.Models.teacher", b =>
                {
                    b.Navigation("teachercourses");
                });
#pragma warning restore 612, 618
        }
    }
}
