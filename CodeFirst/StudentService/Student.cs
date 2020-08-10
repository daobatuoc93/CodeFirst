using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Logging;

namespace CodeFirst.StudentService

{
    [Table("Student", Schema = "main")]
    public class Student
    {
        #region data
        [Key]
        [Column("Student_Id", Order = 1)]
        public long Id { get; set; }

        [MaxLength(30, ErrorMessage = "Họ không dài quá 30 ký tự")]
        [Column("first_name", Order = 2)]
        public string FirstName { get; set; } = "lack of First name for this object!";
        [MaxLength(30, ErrorMessage = "Ten không dài quá 30 ký tự")]
        [Column("last_name", Order = 3)]
        public string LastName { get; set; }
        public string Fullname { get; set; }
        public GradeLevel Year;
        public List<int> ExamScores { get; set; }
        //public virtual List<Student> Students { get; set; }
        //1-n
        public virtual List<Email> Emails { get; set; }
        //n-n
        public virtual ICollection<StudentSubject> Subjects { get; set; }
        //1-1
        public virtual Contact Contacts { get; set; }
        public virtual Account Accounts { get; set; }
        #endregion
    }
    public class Account
    {
        //The ForeignKey need to have same name with property at virtual Student for Lazy loading 
        [ForeignKey("Students")]
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual Student Students { get; set; }
    }
    public class Contact
    {
        //1-1
        [ForeignKey("Students")]
        public long Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Url { get; set; }
        public virtual Student Students { get; set; }
    }
    public class Subject
    {
        //n-n
        public long Id { get; set; }
        public string NameSubject { get; set; }
        public virtual ICollection<StudentSubject> Students { get; set; }
    }
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
    public class Email
    {
        //1-n
        public long EmailId { get; set; }
        public string EmailAdress { get; set; }
        public Student Student { get; set; }
    }
    public class User
    {
        [Key]
        public string Username { get; set; }        
        public string DisplayName { get; set; }
    }
}
