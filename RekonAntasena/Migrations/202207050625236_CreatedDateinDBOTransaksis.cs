namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDateinDBOTransaksis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaksis", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaksis", "CreatedDate");
        }
    }
}
