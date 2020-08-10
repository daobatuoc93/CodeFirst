namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnewDataWithContactandAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("main.Student", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "main.Student",
                c => new
                    {
                        Student_Id = c.Long(nullable: false, identity: true),
                        first_name = c.String(maxLength: 30),
                        last_name = c.String(maxLength: 30),
                        Fullname = c.String(),
                    })
                .PrimaryKey(t => t.Student_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("main.Student", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailId = c.Long(nullable: false, identity: true),
                        EmailAdress = c.String(),
                        Student_Id = c.Long(),
                    })
                .PrimaryKey(t => t.EmailId)
                .ForeignKey("main.Student", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.StudentSubjects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        DateExam = c.DateTime(nullable: false),
                        Result = c.String(),
                        Students_Id = c.Long(),
                        Subjects_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("main.Student", t => t.Students_Id)
                .ForeignKey("dbo.Subjects", t => t.Subjects_Id)
                .Index(t => t.Students_Id)
                .Index(t => t.Subjects_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NameSubject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        display_name1 = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjects", "Subjects_Id", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjects", "Students_Id", "main.Student");
            DropForeignKey("dbo.Emails", "Student_Id", "main.Student");
            DropForeignKey("dbo.Contacts", "Id", "main.Student");
            DropForeignKey("dbo.Accounts", "Id", "main.Student");
            DropIndex("dbo.StudentSubjects", new[] { "Subjects_Id" });
            DropIndex("dbo.StudentSubjects", new[] { "Students_Id" });
            DropIndex("dbo.Emails", new[] { "Student_Id" });
            DropIndex("dbo.Contacts", new[] { "Id" });
            DropIndex("dbo.Accounts", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentSubjects");
            DropTable("dbo.Emails");
            DropTable("dbo.Contacts");
            DropTable("main.Student");
            DropTable("dbo.Accounts");
        }
    }
}
