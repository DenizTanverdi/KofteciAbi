namespace WebMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategoriadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                        UrunId = c.Int(nullable: false),
                        OlusturmaTarihi = c.DateTime(nullable: false),
                        GuncellemeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Urunlers", "Kategori_Id", c => c.Int());
            CreateIndex("dbo.Urunlers", "Kategori_Id");
            AddForeignKey("dbo.Urunlers", "Kategori_Id", "dbo.Kategoris", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urunlers", "Kategori_Id", "dbo.Kategoris");
            DropIndex("dbo.Urunlers", new[] { "Kategori_Id" });
            DropColumn("dbo.Urunlers", "Kategori_Id");
            DropTable("dbo.Kategoris");
        }
    }
}
