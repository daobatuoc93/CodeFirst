using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.StudentService
{
    public interface IStudentService
    {
         IList<Student> GetStudents();
         IEnumerable<Student> GetScoreAverage(float average);
         IEnumerable<Student> Find(long id);
         IEnumerable<Student> DeleteStudent(long id);
         IList<Student> AddSv(Student Sv);
         IEnumerable<ActionResult<string>> FixStudent(Student Newstudent);
    }
}
