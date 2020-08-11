using CodeFirst.Enums;
using CodeFirst.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using System.IO;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                db.Database.Initialize(force: true);
                var studentA = new Student
                {
                    FirstName = "Nguyen",
                    LastName = "Van C",
                    Id = 120,
                    Year = GradeLevel.SecondYear,
                    ExamScores = new List<int> { 91, 82, 81, 79 },
                    Emails = new List<Email> {
                        new Email { EmailAdress = "nguyenvanC@gmail.com", EmailId = 1, },
                        new Email { EmailAdress = "nguyenvanC@icloud.com", EmailId = 2, },
                    },
                    Subjects = new List<StudentSubject>()
                };
                var studentB = new Student
                {
                    FirstName = "Nguyen",
                    LastName = "Van D",
                    Id = 121,
                    Year = GradeLevel.SecondYear,
                    ExamScores = new List<int> { 15, 20, 25, 30 },
                    Emails = new List<Email> {
                        new Email { EmailAdress = "nguyenvanD@gmail.com", EmailId = 3, },
                        new Email { EmailAdress = "nguyenvanD@icloud.com", EmailId = 4, },
                    },
                    Photo = File.ReadAllBytes("C:\\Users\\EMBED\\Pictures\\DSC_02110.jpg"),
                    Subjects = new List<StudentSubject>(),
                    
                };
                var Math = new Subject { NameSubject = "Math", Students = new List<StudentSubject>() };
                var Literature = new Subject { NameSubject = "Literature", Students = new List<StudentSubject>() };
                var Chemistry = new Subject { NameSubject = "Chemistry", Students = new List<StudentSubject>() };

                studentA.Subjects.Add(new StudentSubject { Score = 9, DateExam = new DateTime(2020, 05, 20), Result = "Pass", Subjects = Math });
                studentA.Subjects.Add(new StudentSubject { Score = 7, DateExam = new DateTime(2020, 05, 21, 10, 30, 50), Result = "Pass", Subjects = Literature });
                studentA.Subjects.Add(new StudentSubject { Score = 6, DateExam = new DateTime(2020, 05, 21, 13, 30, 50), Result = "Pass", Subjects = Chemistry });
                Math.Students.Add(new StudentSubject { Score = 4, DateExam = new DateTime(2020, 05, 20), Result = "Fail", Students = studentB, });
                Literature.Students.Add(new StudentSubject { Score = 3, DateExam = new DateTime(2020, 05, 21, 10, 30, 50), Result = "Fail", Students = studentB });
                Chemistry.Students.Add(new StudentSubject { Score = 8, DateExam = new DateTime(2020, 05, 21, 13, 30, 50), Result = "Pass", Students = studentB });
                var AccountA = new Account
                {
                    UserName = "nguyenvanA12345",
                    Password = "123456ewq"
                    
                };
                var AddressStudentA = new Address { State = "Binh thanh", Street = "Dang thuy tram", Zip = "700000" };
                var AddressStudentB = new Address { State = "Tam ky", Street = "nguyen van troi", Zip = "330000" };
                var PhotoA = File.ReadAllBytes("F:\\DB First\\Self\\CodeFirst\\CodeFirst\\CodeFirst\\ComfortGirl.jpg");
                var ContactA = new Contact { Address = "Ho Chi Minh", PhoneNumber = "0965432132"};
                var Schoole = new School { Address = AddressStudentA, NameSchool = "Dong hoi Highshool" };
                db.Schools.Add(Schoole);
                studentA.Address = AddressStudentA;
                studentB.Address = AddressStudentB;
                studentA.Photo = PhotoA;
                studentA.Accounts = AccountA;
                studentA.Contacts = ContactA;
                var AccountB = new Account
                {
                    UserName = "nguyenvanB1990",
                    Password = "123456qew",
                    Students = studentB
                };
                var ContactB = new Contact { Address = "Quang Nam"  , PhoneNumber = "0904218411" ,Students = studentB };
                studentB.Accounts = AccountB;
                studentB.Contacts = ContactB;

                db.Students.Add(studentA);
                db.Students.Add(studentB);
                db.SaveChanges();
                Console.WriteLine("Quering Student  to see Pass or Fail......");
                foreach(var student in db.Students)
                {
                    Console.WriteLine("Student " + student.LastName + "is");
                   
                        foreach (var que in student.Subjects)
                    {
                        
                        Console.WriteLine(que.Result);
                    }
                }
                Console.ReadKey();
            }
            //Using this clause to see pictures student A
            //using (var context = new StudentContext())
            //{
            //    var studentA = context.Students.FirstOrDefault();
            //    File.WriteAllBytes("temp.jpg", studentA.Photo);
            //    System.Diagnostics.Process.Start("temp.jpg");
            //}
        }
    }
}
