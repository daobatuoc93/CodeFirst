namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnotationAttribute : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "Id", newName: "Student_Id");
            AlterColumn("dbo.Students", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Students", "LastName", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            RenameColumn(table: "dbo.Students", name: "Student_Id", newName: "Id");
        }
    }
}
