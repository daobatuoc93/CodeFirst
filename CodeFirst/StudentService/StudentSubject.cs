using System;

namespace CodeFirst.StudentService
{
    public class StudentSubject
    {
        //payload
        public long Id { get; set; }
        public int Score { get; set; }
        public DateTime DateExam { get; set; }
        public string Result { get; set; }
        public Student Students { get; set; }
        public Subject Subjects { get; set; }
    }
}