using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.StudentService
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name = StudentDB")
        {
            //Database.SetInitializer<StudentContext>(new CreateDatabaseIfNotExists<StudentContext>());
            var initializer = new DropCreateDatabaseAlways<StudentContext>();
            Database.SetInitializer(initializer);

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> SubjectCourses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        //public DbSet<StudentSubject> StudentSubjects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name1");
            //add many to many 
            //modelBuilder.Entity<Student>()
            //    .HasMany(p => p.Subjects)
            //    .WithMany(c => (ICollection<Student>)c.Students)
            //    .Map(pc =>
            //    {
            //        pc.MapRightKey("RefStudentId");
            //        pc.MapLeftKey("RefStudentSubjectsId");
            //        pc.ToTable("Student has many StudentSubjects");
            //    });
            //modelBuilder.Entity<Subject>()
            //   .HasMany(p => p.Students)
            //   .WithMany(c => (ICollection<Subject>)c.Subjects)
            //   .Map(pc =>
            //   {
            //       pc.MapRightKey("RefSubjectCourseId");
            //       pc.MapLeftKey("RefStudentSubjects");
            //       pc.ToTable("SubjectCourse has many StudentSubjects");
            //   });
            modelBuilder.Entity<Student>()
                 .HasOptional(p => p.Contacts)
                 .WithRequired(x => x.Students);
            modelBuilder.Entity<Student>()
                 .HasOptional(p => p.Accounts)
                 .WithRequired(x => x.Students);
        }
    }

}
