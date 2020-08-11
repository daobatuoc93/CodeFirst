using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.StudentService
{
    class BuddyConfigClass
    {
        //config AddressMap with buddy
        //AddressMap need to inherit from ComplexTypeConfiguration
        //with Entity Class splitting: EntityTypeConfiguration 
        public class AddressMap : ComplexTypeConfiguration<Address>
        {
            public AddressMap()
            {
                Property(p => p.Street)
                    .HasMaxLength(40)
                    .IsRequired()
                    .HasColumnName("Street");

                Property(p => p.Zip)
                    .HasMaxLength(10)
                    .HasColumnName("Zip")
                    .IsUnicode(false);
            }
        }
        public class StudentMap : EntityTypeConfiguration<Student>
        {
            public StudentMap()
            {
                Map(p =>
                {
                    p.Properties(ph => new { ph.Photo, ph.CurriculumVitae });
                    p.ToTable("Student Data");
                });

                Map(p =>
                {
                    p.Properties(ph => new { ph.FirstName, ph.LastName });
                    p.ToTable("Student Information");
                });
            }
        }
    }
}
