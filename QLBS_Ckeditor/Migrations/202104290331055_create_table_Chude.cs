namespace Quanlybansach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Chude : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chudes",
                c => new
                    {
                        machude = c.String(nullable: false, maxLength: 128, unicode: false),
                        tenchude = c.String(maxLength: 100),
                        Chude_machude = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.machude)
                .ForeignKey("dbo.Chudes", t => t.Chude_machude)
                .Index(t => t.Chude_machude);
            
            AlterColumn("dbo.Sachs", "machude", c => c.String(maxLength: 128, unicode: false));
            CreateIndex("dbo.Sachs", "machude");
            AddForeignKey("dbo.Sachs", "machude", "dbo.Chudes", "machude");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sachs", "machude", "dbo.Chudes");
            DropForeignKey("dbo.Chudes", "Chude_machude", "dbo.Chudes");
            DropIndex("dbo.Chudes", new[] { "Chude_machude" });
            DropIndex("dbo.Sachs", new[] { "machude" });
            AlterColumn("dbo.Sachs", "machude", c => c.String());
            DropTable("dbo.Chudes");
        }
    }
}
