using Microsoft.EntityFrameworkCore;
using hight_school_follow_up.Models;

namespace hight_school_follow_up.Properties.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<StudentCourseGrade> StudentCourseGrades { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Parent> Parents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("connectionDb");
                // Replace "YourConnectionString" with your actual database connection string
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
       
            modelBuilder.Entity<TeacherCourse>()
                .HasKey(tc => tc.teachercourseid);

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.teacher)
                .WithMany()
                .HasForeignKey(tc => tc.teacherid);

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.course)
                .WithMany()
                .HasForeignKey(tc => tc.courseid);

            modelBuilder.Entity<StudentParent>()
                .HasKey(sp => sp.studentparentid);

            modelBuilder.Entity<StudentParent>()
                .HasOne(sp => sp.Student)
                .WithMany()
                .HasForeignKey(sp => sp.studentid);

            modelBuilder.Entity<StudentParent>()
                .HasOne(sp => sp.parent)
                .WithMany()
                .HasForeignKey(sp => sp.parentid);

            modelBuilder.Entity<StudentCourseGrade>()
        .HasKey(scg => scg.studentcoursegradeid);

            modelBuilder.Entity<StudentCourseGrade>()
                .HasOne(scg => scg.student)
                .WithMany(s => s.studentcoursegrades)
                .HasForeignKey(scg => scg.studentid);

            modelBuilder.Entity<StudentCourseGrade>()
                .HasOne(scg => scg.course)
                .WithMany(c => c.studentcoursegrades)
                .HasForeignKey(scg => scg.courseid);

            modelBuilder.Entity<StudentCourseGrade>()
                .HasOne(scg => scg.grade)
                .WithMany(g => g.studentcoursegrades)
                .HasForeignKey(scg => scg.gradeid);

        

        modelBuilder.Entity<Grade>()
                .HasKey(g => g.gradeid);

            modelBuilder.Entity<Parent>()
                .HasKey(p => p.parentid);
           

            modelBuilder.Entity<Parent>()
                .Property(p => p.parentname)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Parent>()
                .HasCheckConstraint("CK_ParentName_LettersAndSpaces",
                    "[ParentName] LIKE '%[a-zA-Z ]%'");

          

            // Add any further configurations, relationships, or constraints for CourseGrade entity
        }
        private readonly AppDBcontext _context;


        

    }
}
