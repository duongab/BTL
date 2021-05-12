namespace Quanlybansach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Chitietdonhang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chitietdonhangs",
                c => new
                    {
                        soluong = c.String(nullable: false, maxLength: 128, unicode: false),
                        dongia = c.String(unicode: false),
                        madh = c.String(maxLength: 128, unicode: false),
                        masach = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.soluong)
                .ForeignKey("dbo.Donhangs", t => t.madh)
                .ForeignKey("dbo.Sachs", t => t.masach)
                .Index(t => t.madh)
                .Index(t => t.masach);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chitietdonhangs", "masach", "dbo.Sachs");
            DropForeignKey("dbo.Chitietdonhangs", "madh", "dbo.Donhangs");
            DropIndex("dbo.Chitietdonhangs", new[] { "masach" });
            DropIndex("dbo.Chitietdonhangs", new[] { "madh" });
            DropTable("dbo.Chitietdonhangs");
        }
    }
}
