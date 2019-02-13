namespace WebMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Baslik", c => c.String());
            AddColumn("dbo.Images", "Aciklama", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Aciklama");
            DropColumn("dbo.Images", "Baslik");
        }
    }
}
