namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addisu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataAntasenas", "nomorRefTransaksi2", c => c.String());
            AddColumn("dbo.DataAntasenas", "kontrak2", c => c.String());
            AddColumn("dbo.LHBUs", "nomorRefTransaksi2", c => c.String());
            AddColumn("dbo.LHBUs", "kontrak2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LHBUs", "kontrak2");
            DropColumn("dbo.LHBUs", "nomorRefTransaksi2");
            DropColumn("dbo.DataAntasenas", "kontrak2");
            DropColumn("dbo.DataAntasenas", "nomorRefTransaksi2");
        }
    }
}
