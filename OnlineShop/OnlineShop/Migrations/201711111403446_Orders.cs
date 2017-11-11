namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Order", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Order", "Address", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Order", "Phone", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AspNetUsers", "UserDetails_ZipCode", c => c.String());
            AlterColumn("dbo.Order", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Order", "Street");
            DropColumn("dbo.Order", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "PhoneNumber", c => c.String());
            AddColumn("dbo.Order", "Street", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order", "Email", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserDetails_ZipCode");
            DropColumn("dbo.Order", "Phone");
            DropColumn("dbo.Order", "Address");
            RenameIndex(table: "dbo.Order", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Order", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
