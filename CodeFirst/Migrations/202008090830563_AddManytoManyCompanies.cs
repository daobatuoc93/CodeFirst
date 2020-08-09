namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManytoManyCompanies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NameCompany = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCompanies",
                c => new
                    {
                        Student_Id = c.Long(nullable: false),
                        Company_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Company_Id })
                .ForeignKey("main.Student", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.StudentCompanies", "Student_Id", "main.Student");
            DropIndex("dbo.StudentCompanies", new[] { "Company_Id" });
            DropIndex("dbo.StudentCompanies", new[] { "Student_Id" });
            DropTable("dbo.StudentCompanies");
            DropTable("dbo.Companies");
        }
    }
}
