namespace WebMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategoriupdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "Acıklama", c => c.String());
            DropColumn("dbo.Kategoris", "Açıklama");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "Açıklama", c => c.String());
            DropColumn("dbo.Kategoris", "Acıklama");
        }
    }
}
