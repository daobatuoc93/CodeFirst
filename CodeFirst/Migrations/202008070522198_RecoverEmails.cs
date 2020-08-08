namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecoverEmails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailId = c.Long(nullable: false, identity: true),
                        EmailAdress = c.String(),
                        Student_Id = c.Long(),
                    })
                .PrimaryKey(t => t.EmailId)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
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
            DropForeignKey("dbo.Emails", "Student_Id", "dbo.Students");
            DropIndex("dbo.Emails", new[] { "Student_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Students");
            DropTable("dbo.Emails");
        }
    }
}
