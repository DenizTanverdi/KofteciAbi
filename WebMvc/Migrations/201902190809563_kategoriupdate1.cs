namespace WebMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategoriupdate1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Kategoris", new[] { "urunId" });
            AddColumn("dbo.Kategoris", "url", c => c.String());
            AddColumn("dbo.Kategoris", "Açıklama", c => c.String());
            AlterColumn("dbo.Kategoris", "urunId", c => c.Int());
            CreateIndex("dbo.Kategoris", "urunId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Kategoris", new[] { "urunId" });
            AlterColumn("dbo.Kategoris", "urunId", c => c.Int(nullable: false));
            DropColumn("dbo.Kategoris", "Açıklama");
            DropColumn("dbo.Kategoris", "url");
            CreateIndex("dbo.Kategoris", "urunId");
        }
    }
}
