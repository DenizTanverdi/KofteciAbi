namespace WebMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategoriupdate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kategoris", "urunId", "dbo.Urunlers");
            DropIndex("dbo.Kategoris", new[] { "urunId" });
            AddColumn("dbo.Urunlers", "kategoriId", c => c.Int());
            CreateIndex("dbo.Urunlers", "kategoriId");
            AddForeignKey("dbo.Urunlers", "kategoriId", "dbo.Urunlers", "Id");
            AddForeignKey("dbo.Urunlers", "kategoriId", "dbo.Kategoris", "Id");
            DropColumn("dbo.Kategoris", "urunId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "urunId", c => c.Int());
            DropForeignKey("dbo.Urunlers", "kategoriId", "dbo.Kategoris");
            DropForeignKey("dbo.Urunlers", "kategoriId", "dbo.Urunlers");
            DropIndex("dbo.Urunlers", new[] { "kategoriId" });
            DropColumn("dbo.Urunlers", "kategoriId");
            CreateIndex("dbo.Kategoris", "urunId");
            AddForeignKey("dbo.Kategoris", "urunId", "dbo.Urunlers", "Id");
        }
    }
}
