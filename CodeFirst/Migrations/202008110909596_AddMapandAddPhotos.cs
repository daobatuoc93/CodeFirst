namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMapandAddPhotos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student Information",
                c => new
                    {
                        Student_Id = c.Long(nullable: false),
                        first_name = c.String(maxLength: 30),
                        last_name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Student_Id)
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Student11",
                c => new
                    {
                        Student_Id = c.Long(nullable: false),
                        Fullname = c.String(),
                        Address_Street = c.String(),
                        Address_City = c.String(),
                        Address_State = c.String(),
                        Address_Zip = c.String(),
                    })
                .PrimaryKey(t => t.Student_Id);
            
            AddColumn("dbo.Student", "Photo", c => c.Binary());
            AddColumn("dbo.Student", "CurriculumVitae", c => c.Binary());
            AddColumn("dbo.Schools", "Address_Street", c => c.String());
            DropColumn("dbo.Student", "first_name");
            DropColumn("dbo.Student", "last_name");
            DropColumn("dbo.Student", "Fullname");
            DropColumn("dbo.Student", "Address_Stress");
            DropColumn("dbo.Student", "Address_City");
            DropColumn("dbo.Student", "Address_State");
            DropColumn("dbo.Student", "Address_Zip");
            DropColumn("dbo.Schools", "Address_Stress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schools", "Address_Stress", c => c.String());
            AddColumn("dbo.Student", "Address_Zip", c => c.String());
            AddColumn("dbo.Student", "Address_State", c => c.String());
            AddColumn("dbo.Student", "Address_City", c => c.String());
            AddColumn("dbo.Student", "Address_Stress", c => c.String());
            AddColumn("dbo.Student", "Fullname", c => c.String());
            AddColumn("dbo.Student", "last_name", c => c.String(maxLength: 30));
            AddColumn("dbo.Student", "first_name", c => c.String(maxLength: 30));
            DropForeignKey("dbo.Student Information", "Student_Id", "dbo.Student");
            DropIndex("dbo.Student Information", new[] { "Student_Id" });
            DropColumn("dbo.Schools", "Address_Street");
            DropColumn("dbo.Student", "CurriculumVitae");
            DropColumn("dbo.Student", "Photo");
            DropTable("dbo.Student11");
            DropTable("dbo.Student Information");
        }
    }
}
