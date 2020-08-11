using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.StudentService
{
    public class School
    {
        public long Id { get; set; }
        public string NameSchool { get; set; }
        public Address Address { get; set; }
    }
}
