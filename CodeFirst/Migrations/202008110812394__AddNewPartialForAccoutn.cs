namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _AddNewPartialForAccoutn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "_userName", c => c.String());
            AddColumn("dbo.Student", "_passWord", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "_passWord");
            DropColumn("dbo.Student", "_userName");
        }
    }
}
