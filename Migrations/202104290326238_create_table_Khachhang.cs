namespace Quanlybansach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Khachhang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Khachhangs",
                c => new
                    {
                        makh = c.String(nullable: false, maxLength: 128, unicode: false),
                        tenkh = c.String(maxLength: 100),
                        taikhoan = c.String(unicode: false),
                        matkhau = c.String(unicode: false),
                        email = c.String(unicode: false),
                        diachi = c.String(maxLength: 100),
                        dienthoai = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.makh);
            
            AlterColumn("dbo.Donhangs", "makh", c => c.String(maxLength: 128, unicode: false));
            CreateIndex("dbo.Donhangs", "makh");
            AddForeignKey("dbo.Donhangs", "makh", "dbo.Khachhangs", "makh");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donhangs", "makh", "dbo.Khachhangs");
            DropIndex("dbo.Donhangs", new[] { "makh" });
            AlterColumn("dbo.Donhangs", "makh", c => c.String(unicode: false));
            DropTable("dbo.Khachhangs");
        }
    }
}
