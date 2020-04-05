using System;
using Data.Model;
using Data.Model.AdminModels;
using Data.Model.ExamModels;
using Data.Model.SchoolModels;
using Data.Model.StudentModels;
using Data.Model.TeacherModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ubiety.Dns.Core;

namespace Data
{
    public class MasterContext : DbContext
    {
        public MasterContext()
        {

        }
        public MasterContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<SchoolModel> Schools { set; get; }
        public DbSet<DepartmentModel> Departments { set; get; }
        public DbSet<TeacherModel> Teachers { set; get; }
        public DbSet<ClassModel> Classes { set; get; }
        public DbSet<StudentModel> Students { set; get; }
        public DbSet<LessonModel> Lessons { set; get; }
        public DbSet<SubjectModel> Subjects { set; get; }
        public DbSet<QuestionModel> Questions { set; get; }
        public DbSet<QuestionAnswerModel> QuestionAnswers { set; get; }
        public DbSet<TestModel> Tests { set; get; }
        public DbSet<StudentAnswerModel> StudentAnswers { set; get; }
        public DbSet<QuestionTypeModel> QuestionTypes { set; get; }
        public DbSet<ExamModel> Exams { set; get; }
        public DbSet<BranchModel> Branchs { get; set; }
        public DbSet<ExamToStudentModel> ExamToStudent { get; set; }
        public DbSet<AdminModel> Admins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //department-school Foreign
            modelBuilder.Entity<SchoolModel>()//referans alınan model
                .HasMany(p => p.Departments)  //Hangi modele foregin bağladığımız 
                .WithOne(s => s.School) //hangi modelden alınacağı
                .HasForeignKey(k => k.SchoolId);// foreign olan sütun
           
            //teacher-department Foreign
            modelBuilder.Entity<DepartmentModel>()
                .HasMany(p => p.Teachers)
                .WithOne(s => s.Department)
                .HasForeignKey(k => k.DepartmentId);

            //class-department Foreign
            modelBuilder.Entity<SchoolModel>()
                .HasMany(p => p.Classes)
                .WithOne(s => s.School)
                .HasForeignKey(k => k.SchoolId);
            //student-class Foreign
            modelBuilder.Entity<ClassModel>()
                .HasMany(p => p.Students)
                .WithOne(s => s.Classes)
                .HasForeignKey(k => k.ClassId);

            //subject-lesson Foreign
            modelBuilder.Entity<LessonModel>()
                .HasMany(p => p.Subjects)
                .WithOne(s => s.Lesson)
                .HasForeignKey(k => k.LessonId);

            //questionAnswer question Foreign
            modelBuilder.Entity<QuestionModel>()
                .HasMany(p => p.QuestionAnswers)
                .WithOne(s => s.Question)
                .HasForeignKey(k => k.QuestionId);

            //question subject Foreign
            modelBuilder.Entity<SubjectModel>()
                .HasMany(p => p.Questions)
                .WithOne(s => s.Subject)
                .HasForeignKey(k => k.SubjectId);

            //question teacher Foreign
            modelBuilder.Entity<TeacherModel>()
                .HasMany(p => p.Questions)
                .WithOne(s => s.Teacher)
                .HasForeignKey(k => k.TeacherId);

            //question questionType Foreign
            modelBuilder.Entity<QuestionTypeModel>()
                .HasMany(p => p.Questions)
                .WithOne(s => s.QuestionType)
                .HasForeignKey(k => k.QuestionTypeId);

            //question classes Foreign
            modelBuilder.Entity<ClassModel>()
                .HasMany(p => p.Questions)
                .WithOne(s => s.Classes)
                .HasForeignKey(k => k.ClassId);

            //question lesson Foreign
            modelBuilder.Entity<LessonModel>()
                .HasMany(p => p.Questions)
                .WithOne(s => s.Lesson)
                .HasForeignKey(k => k.LessonId);

            //question test Foreign
            modelBuilder.Entity<QuestionModel>()
                .HasMany(p => p.Tests)
                .WithOne(s => s.Question)
                .HasForeignKey(k => k.QuestionId);

            //Lesson test Foreign
            modelBuilder.Entity<LessonModel>()
                .HasMany(p => p.Tests)
                .WithOne(s => s.Lesson)
                .HasForeignKey(k => k.LessonId);

            //Lesson test Foreign
            modelBuilder.Entity<TeacherModel>()
                .HasMany(p => p.Tests)
                .WithOne(s => s.Teacher)
                .HasForeignKey(k => k.TeacherId);

            //Exam teacher Foreign
            modelBuilder.Entity<TeacherModel>()
                .HasMany(p => p.Exams)
                .WithOne(s => s.Teacher)
                .HasForeignKey(k => k.TeacherId);

            //Exam Test Foreign
            modelBuilder.Entity<TestModel>()
                .HasMany(p => p.Exams)
                .WithOne(s => s.Test)
                .HasForeignKey(k => k.TestId);


            //StudentAnswer Test Foreign
            modelBuilder.Entity<TestModel>()
                .HasMany(p => p.StudentAnswers)
                .WithOne(s => s.Test)
                .HasForeignKey(k => k.TestId);


            //StudentAnswer Question Foreign
            modelBuilder.Entity<QuestionModel>()
                .HasMany(p => p.StudentAnswers)
                .WithOne(s => s.Question)
                .HasForeignKey(k => k.QuestionId);

            //StudentAnswer Student Foreign
            modelBuilder.Entity<StudentModel>()
                .HasMany(p => p.StudentAnswers)
                .WithOne(s => s.Student)
                .HasForeignKey(k => k.StudentId);

            //Teacher Branch Foreign
            modelBuilder.Entity<BranchModel>()
                .HasMany(p => p.Teachers)
                .WithOne(s => s.Branch)
                .HasForeignKey(k => k.BranchId);

            //ExamToStudent Exam Foreign
            modelBuilder.Entity<ExamModel>()
                .HasMany(p => p.ExamToStudents)
                .WithOne(s => s.Exam)
                .HasForeignKey(k => k.ExamId);

            //ExamToStudent Student Foreign
            modelBuilder.Entity<StudentModel>()
                .HasMany(p => p.ExamToStudents)
                .WithOne(s => s.Student)
                .HasForeignKey(k => k.StudentId);

            modelBuilder.Entity<SchoolModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<DepartmentModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<TeacherModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<ClassModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<StudentModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<LessonModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<SubjectModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<QuestionModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<QuestionAnswerModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<TestModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<StudentAnswerModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<QuestionTypeModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<ExamModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<BranchModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<ExamToStudentModel>().Property(c => c.Status).HasConversion<short>();
            modelBuilder.Entity<AdminModel>().Property(c => c.Status).HasConversion<short>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(Environment.GetEnvironmentVariable("MYSQL_URI"));
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
