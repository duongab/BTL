namespace Quanlybansach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Tacgia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nhaxuatbans",
                c => new
                    {
                        manxb = c.String(nullable: false, maxLength: 128, unicode: false),
                        tennxb = c.String(maxLength: 100),
                        diachi = c.String(maxLength: 100),
                        dienthoai = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.manxb);
            
            AlterColumn("dbo.Sachs", "manxb", c => c.String(maxLength: 128, unicode: false));
            CreateIndex("dbo.Sachs", "manxb");
            AddForeignKey("dbo.Sachs", "manxb", "dbo.Nhaxuatbans", "manxb");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sachs", "manxb", "dbo.Nhaxuatbans");
            DropIndex("dbo.Sachs", new[] { "manxb" });
            AlterColumn("dbo.Sachs", "manxb", c => c.String());
            DropTable("dbo.Nhaxuatbans");
        }
    }
}
