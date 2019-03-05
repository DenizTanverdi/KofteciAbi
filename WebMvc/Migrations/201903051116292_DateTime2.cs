namespace WebMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "OlusturmaTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Images", "GuncellemeTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Kategoris", "OlusturmaTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Kategoris", "GuncellemeTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Urunlers", "OlusturmaTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Urunlers", "GuncellemeTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subes", "OlusturmaTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subes", "GuncellemeTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "OlusturmaTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "GuncellemeTarihi", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "GuncellemeTarihi", c => c.DateTime());
            AlterColumn("dbo.Users", "OlusturmaTarihi", c => c.DateTime());
            AlterColumn("dbo.Subes", "GuncellemeTarihi", c => c.DateTime());
            AlterColumn("dbo.Subes", "OlusturmaTarihi", c => c.DateTime());
            AlterColumn("dbo.Urunlers", "GuncellemeTarihi", c => c.DateTime());
            AlterColumn("dbo.Urunlers", "OlusturmaTarihi", c => c.DateTime());
            AlterColumn("dbo.Kategoris", "GuncellemeTarihi", c => c.DateTime());
            AlterColumn("dbo.Kategoris", "OlusturmaTarihi", c => c.DateTime());
            AlterColumn("dbo.Images", "GuncellemeTarihi", c => c.DateTime());
            AlterColumn("dbo.Images", "OlusturmaTarihi", c => c.DateTime());
        }
    }
}
