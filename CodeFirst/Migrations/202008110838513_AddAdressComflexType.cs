namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdressComflexType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Address_Stress", c => c.String());
            AddColumn("dbo.Student", "Address_City", c => c.String());
            AddColumn("dbo.Student", "Address_State", c => c.String());
            AddColumn("dbo.Student", "Address_Zip", c => c.String());
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        display_name1 = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            DropColumn("dbo.Student", "Address_Zip");
            DropColumn("dbo.Student", "Address_State");
            DropColumn("dbo.Student", "Address_City");
            DropColumn("dbo.Student", "Address_Stress");
        }
    }
}
