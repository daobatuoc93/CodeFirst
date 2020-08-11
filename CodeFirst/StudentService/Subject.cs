using System.Collections.Generic;

namespace CodeFirst.StudentService
{
    public class Subject
    {
        //n-n
        public long Id { get; set; }
        public string NameSubject { get; set; }
        public virtual ICollection<StudentSubject> Students { get; set; }
    }
}