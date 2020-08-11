using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.StudentService
{
    public class Address
    {
        //add address with complex Type
        //If change customized table follow below:
        //
        //[Column("Stress")]
        //[MaxLength(40)]
        //[Required]
        //if change with fluent api let's config in StudentContext: at modelBuilder.
        // 
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}