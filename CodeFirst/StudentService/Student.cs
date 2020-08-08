using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column("last_name", Order = 2)]
        public string LastName { get; set; }
        public string Fullname { get; set; }
        public GradeLevel Year;
        public List<int> ExamScores { get; set; }
        //public virtual List<Student> Students { get; set; }
        public virtual List<Email> Emails { get; set; }

        #endregion
    }
    public class Email
    {
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
