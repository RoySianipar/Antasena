namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lagi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaksis", "TsuAntasenaId", c => c.Int());
            AddColumn("dbo.Transaksis", "TsuLHBUId", c => c.Int());
            CreateIndex("dbo.Transaksis", "TsuAntasenaId");
            CreateIndex("dbo.Transaksis", "TsuLHBUId");
            AddForeignKey("dbo.Transaksis", "TsuAntasenaId", "dbo.TsuAntasenas", "Id");
            AddForeignKey("dbo.Transaksis", "TsuLHBUId", "dbo.TsuLHBUs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaksis", "TsuLHBUId", "dbo.TsuLHBUs");
            DropForeignKey("dbo.Transaksis", "TsuAntasenaId", "dbo.TsuAntasenas");
            DropIndex("dbo.Transaksis", new[] { "TsuLHBUId" });
            DropIndex("dbo.Transaksis", new[] { "TsuAntasenaId" });
            DropColumn("dbo.Transaksis", "TsuLHBUId");
            DropColumn("dbo.Transaksis", "TsuAntasenaId");
        }
    }
}
