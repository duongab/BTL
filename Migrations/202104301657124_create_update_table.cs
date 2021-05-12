namespace Quanlybansach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_update_table : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Role", newName: "Roles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Roles", newName: "Role");
        }
    }
}
