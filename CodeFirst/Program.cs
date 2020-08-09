using CodeFirst.Enums;
using CodeFirst.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                var student = new Student
                {
                    FirstName = "Nguyen",
                    LastName = "Van Tai B",
                    Id = 120,
                    Year = GradeLevel.SecondYear,
                    ExamScores = new List<int> { 91, 82, 81, 79 },
                    Emails = new List<Email> {
                    new Email
                    {
                        EmailAdress = "nguyenvantaiB@123456",
                        EmailId=1,
                    },
                    new Email
                    {
                        EmailAdress = "nguyenvantaiB@199341",
                        EmailId=1,
                    },
                    }

                };
                
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }
}
