namespace WebMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategoriupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Urunlers", "Kategori_Id", "dbo.Kategoris");
            DropIndex("dbo.Urunlers", new[] { "Kategori_Id" });
            AlterColumn("dbo.Kategoris", "urunId", c => c.Int());
            CreateIndex("dbo.Kategoris", "urunId");
            AddForeignKey("dbo.Kategoris", "urunId", "dbo.Urunlers", "Id");
            DropColumn("dbo.Urunlers", "Kategori_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Urunlers", "Kategori_Id", c => c.Int());
            DropForeignKey("dbo.Kategoris", "urunId", "dbo.Urunlers");
            DropIndex("dbo.Kategoris", new[] { "urunId" });
            AlterColumn("dbo.Kategoris", "urunId", c => c.Int(nullable: false));
            CreateIndex("dbo.Urunlers", "Kategori_Id");
            AddForeignKey("dbo.Urunlers", "Kategori_Id", "dbo.Kategoris", "Id");
        }
    }
}
