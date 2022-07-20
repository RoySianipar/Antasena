namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaru : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaksis", "TsuAntasenaId", "dbo.TsuAntasenas");
            DropForeignKey("dbo.Transaksis", "TsuLHBUId", "dbo.TsuLHBUs");
            DropIndex("dbo.Transaksis", new[] { "TsuAntasenaId" });
            DropIndex("dbo.Transaksis", new[] { "TsuLHBUId" });
            DropColumn("dbo.Transaksis", "TsuAntasenaId");
            DropColumn("dbo.Transaksis", "TsuLHBUId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaksis", "TsuLHBUId", c => c.Int());
            AddColumn("dbo.Transaksis", "TsuAntasenaId", c => c.Int());
            CreateIndex("dbo.Transaksis", "TsuLHBUId");
            CreateIndex("dbo.Transaksis", "TsuAntasenaId");
            AddForeignKey("dbo.Transaksis", "TsuLHBUId", "dbo.TsuLHBUs", "Id");
            AddForeignKey("dbo.Transaksis", "TsuAntasenaId", "dbo.TsuAntasenas", "Id");
        }
    }
}
