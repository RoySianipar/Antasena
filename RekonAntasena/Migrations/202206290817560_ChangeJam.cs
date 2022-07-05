namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeJam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DataAntasenas", "jamTransaksi", c => c.String());
            AlterColumn("dbo.LHBUs", "jamTransaksi", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LHBUs", "jamTransaksi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DataAntasenas", "jamTransaksi", c => c.DateTime(nullable: false));
        }
    }
}
