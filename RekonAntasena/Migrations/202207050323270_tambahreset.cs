namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahreset : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataAntasenas", "isDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.LHBUs", "isDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transaksis", "isDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.TrDataAntasenas", "isDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrDataAntasenas", "isDelete");
            DropColumn("dbo.Transaksis", "isDelete");
            DropColumn("dbo.LHBUs", "isDelete");
            DropColumn("dbo.DataAntasenas", "isDelete");
        }
    }
}
