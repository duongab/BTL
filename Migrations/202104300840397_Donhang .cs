namespace Quanlybansach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donhang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128, unicode: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Role");
        }
    }
}
