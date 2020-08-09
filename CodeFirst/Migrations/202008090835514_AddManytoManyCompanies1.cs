namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManytoManyCompanies1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Companies", newName: "SubjectCourses");
            RenameTable(name: "dbo.StudentCompanies", newName: "StudentSubjectCourses");
            RenameColumn(table: "dbo.StudentSubjectCourses", name: "Company_Id", newName: "SubjectCourse_Id");
            RenameIndex(table: "dbo.StudentSubjectCourses", name: "IX_Company_Id", newName: "IX_SubjectCourse_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentSubjectCourses", name: "IX_SubjectCourse_Id", newName: "IX_Company_Id");
            RenameColumn(table: "dbo.StudentSubjectCourses", name: "SubjectCourse_Id", newName: "Company_Id");
            RenameTable(name: "dbo.StudentSubjectCourses", newName: "StudentCompanies");
            RenameTable(name: "dbo.SubjectCourses", newName: "Companies");
        }
    }
}
