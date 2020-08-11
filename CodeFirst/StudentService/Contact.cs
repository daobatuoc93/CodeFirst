using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.StudentService
{
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
}