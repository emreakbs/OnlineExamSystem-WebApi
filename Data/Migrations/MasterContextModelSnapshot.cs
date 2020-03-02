﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MasterContext))]
    partial class MasterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("Data.Model.AdminModels.AdminModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdminEMail")
                        .IsRequired();

                    b.Property<string>("AdminMediumName");

                    b.Property<string>("AdminName")
                        .IsRequired();

                    b.Property<string>("AdminPassword")
                        .IsRequired();

                    b.Property<string>("AdminSurname")
                        .IsRequired();

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Data.Model.ClassModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<int>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Data.Model.DepartmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.Property<int>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Data.Model.ExamModels.ExamModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExamCreateTime");

                    b.Property<string>("ExamStatus");

                    b.Property<int>("TeacherId");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TestId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Data.Model.ExamModels.ExamToStudentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExamId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("ExamToStudent");
                });

            modelBuilder.Entity("Data.Model.ExamModels.QuestionAnswerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QuestionAnswerText")
                        .IsRequired();

                    b.Property<bool>("QuestionAnswerType");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("Data.Model.ExamModels.QuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<int>("LessonId");

                    b.Property<DateTime>("QuestionCreateTime");

                    b.Property<decimal?>("QuestionPoint");

                    b.Property<string>("QuestionText")
                        .IsRequired();

                    b.Property<int>("QuestionTypeId");

                    b.Property<int>("SubjectId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("LessonId");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Data.Model.ExamModels.QuestionTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QuestionTypeDescription")
                        .IsRequired();

                    b.Property<string>("QuestionTypeText")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("Data.Model.ExamModels.SubjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LessonId");

                    b.Property<string>("SubjectName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Data.Model.ExamModels.TestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LessonId");

                    b.Property<int>("QuestionId");

                    b.Property<int>("TeacherId");

                    b.Property<DateTime>("TestCreateTime");

                    b.Property<string>("TestTime");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Data.Model.LessonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LessonName");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Data.Model.PositionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PositionName");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Data.Model.SchoolModels.SchoolModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SchoolName")
                        .IsRequired();

                    b.Property<string>("SchoolWebSite");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Data.Model.StudentModels.StudentAnswerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.Property<bool>("StudentAnswerStatus");

                    b.Property<string>("StudentAnswerText");

                    b.Property<int>("StudentId");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestId");

                    b.ToTable("StudentAnswers");
                });

            modelBuilder.Entity("Data.Model.StudentModels.StudentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<string>("StudentFirstName")
                        .IsRequired();

                    b.Property<string>("StudentHashPassword");

                    b.Property<string>("StudentLastName");

                    b.Property<string>("StudentMail");

                    b.Property<string>("StudentMediumName");

                    b.Property<string>("StudentNickName");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Data.Model.TeacherModels.BranchModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BranchName");

                    b.HasKey("Id");

                    b.ToTable("Branchs");
                });

            modelBuilder.Entity("Data.Model.TeacherModels.TeacherModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BranchId");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("PositionId");

                    b.Property<string>("TeacherFirstName")
                        .IsRequired();

                    b.Property<string>("TeacherLastName")
                        .IsRequired();

                    b.Property<string>("TeacherMail")
                        .IsRequired();

                    b.Property<string>("TeacherMediumName");

                    b.Property<string>("TeacherPassword")
                        .IsRequired();

                    b.Property<bool>("TeacherStatus");

                    b.Property<string>("TeacherUserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Data.Model.AdminModels.AdminModel", b =>
                {
                    b.HasOne("Data.Model.PositionModel", "Position")
                        .WithMany("Admins")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.ClassModel", b =>
                {
                    b.HasOne("Data.Model.SchoolModels.SchoolModel", "School")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.DepartmentModel", b =>
                {
                    b.HasOne("Data.Model.SchoolModels.SchoolModel", "School")
                        .WithMany("Departments")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.ExamModels.ExamModel", b =>
                {
                    b.HasOne("Data.Model.TeacherModels.TeacherModel", "Teacher")
                        .WithMany("Exams")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.ExamModels.TestModel", "Test")
                        .WithMany("Exams")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.ExamModels.ExamToStudentModel", b =>
                {
                    b.HasOne("Data.Model.ExamModels.ExamModel", "Exam")
                        .WithMany("ExamToStudents")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.StudentModels.StudentModel", "Student")
                        .WithMany("ExamToStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.ExamModels.QuestionAnswerModel", b =>
                {
                    b.HasOne("Data.Model.ExamModels.QuestionModel", "Question")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.ExamModels.QuestionModel", b =>
                {
                    b.HasOne("Data.Model.ClassModel", "Classes")
                        .WithMany("Questions")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.LessonModel", "Lesson")
                        .WithMany("Questions")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.ExamModels.QuestionTypeModel", "QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.ExamModels.SubjectModel", "Subject")
                        .WithMany("Questions")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.TeacherModels.TeacherModel", "Teacher")
                        .WithMany("Questions")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.ExamModels.SubjectModel", b =>
                {
                    b.HasOne("Data.Model.LessonModel", "Lesson")
                        .WithMany("Subjects")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.ExamModels.TestModel", b =>
                {
                    b.HasOne("Data.Model.LessonModel", "Lesson")
                        .WithMany("Tests")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.ExamModels.QuestionModel", "Question")
                        .WithMany("Tests")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.TeacherModels.TeacherModel", "Teacher")
                        .WithMany("Tests")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.StudentModels.StudentAnswerModel", b =>
                {
                    b.HasOne("Data.Model.ExamModels.QuestionModel", "Question")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.StudentModels.StudentModel", "Student")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.ExamModels.TestModel", "Test")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.StudentModels.StudentModel", b =>
                {
                    b.HasOne("Data.Model.ClassModel", "Classes")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Model.TeacherModels.TeacherModel", b =>
                {
                    b.HasOne("Data.Model.TeacherModels.BranchModel", "Branch")
                        .WithMany("Teachers")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.DepartmentModel", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Model.PositionModel", "Position")
                        .WithMany("Teachers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}