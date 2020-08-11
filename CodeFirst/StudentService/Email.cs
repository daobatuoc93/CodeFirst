namespace CodeFirst.StudentService
{
    public class Email
    {
        //1-n
        public long EmailId { get; set; }
        public string EmailAdress { get; set; }
        public Student Student { get; set; }
    }
}