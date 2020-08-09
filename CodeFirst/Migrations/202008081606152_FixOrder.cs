namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixOrder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "main.Student", name: "FirstName", newName: "first_name");
            RenameColumn(table: "main.Student", name: "LastName", newName: "last_name");
            AddColumn("main.Student", "Fullname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("main.Student", "Fullname");
            RenameColumn(table: "main.Student", name: "last_name", newName: "LastName");
            RenameColumn(table: "main.Student", name: "first_name", newName: "FirstName");
        }
    }
}
