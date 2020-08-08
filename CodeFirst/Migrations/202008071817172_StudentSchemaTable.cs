namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentSchemaTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Students", newName: "Student");
            MoveTable(name: "dbo.Student", newSchema: "main");
        }
        
        public override void Down()
        {
            MoveTable(name: "main.Student", newSchema: "dbo");
            RenameTable(name: "dbo.Student", newName: "Students");
        }
    }
}
