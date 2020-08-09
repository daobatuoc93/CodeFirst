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
            Database.SetInitializer<StudentContext>(new CreateDatabaseIfNotExists<StudentContext>());
            //var initializer = new DropCreateDatabaseAlways<StudentContext>();
            //Database.SetInitializer(initializer);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SubjectCourse> Companies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name1");

        }
    }

}
