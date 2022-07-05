namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrDataAntasenas", "DataAntasenaId", "dbo.DataAntasenas");
            DropForeignKey("dbo.TrDataAntasenas", "TransaksiId", "dbo.Transaksis");
            DropIndex("dbo.TrDataAntasenas", new[] { "TransaksiId" });
            DropIndex("dbo.TrDataAntasenas", new[] { "DataAntasenaId" });
            AddColumn("dbo.TrDataAntasenas", "NamaFile", c => c.String());
            AddColumn("dbo.TrDataAntasenas", "Jenis", c => c.Int(nullable: false));
            AddColumn("dbo.TrDataAntasenas", "UploadFile", c => c.DateTime(nullable: false));
            DropColumn("dbo.TrDataAntasenas", "TransaksiId");
            DropColumn("dbo.TrDataAntasenas", "DataAntasenaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrDataAntasenas", "DataAntasenaId", c => c.Int());
            AddColumn("dbo.TrDataAntasenas", "TransaksiId", c => c.Int());
            DropColumn("dbo.TrDataAntasenas", "UploadFile");
            DropColumn("dbo.TrDataAntasenas", "Jenis");
            DropColumn("dbo.TrDataAntasenas", "NamaFile");
            CreateIndex("dbo.TrDataAntasenas", "DataAntasenaId");
            CreateIndex("dbo.TrDataAntasenas", "TransaksiId");
            AddForeignKey("dbo.TrDataAntasenas", "TransaksiId", "dbo.Transaksis", "Id");
            AddForeignKey("dbo.TrDataAntasenas", "DataAntasenaId", "dbo.DataAntasenas", "Id");
        }
    }
}
