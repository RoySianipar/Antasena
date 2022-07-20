namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ulang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrDataLHBUs", "LHBU_Id", "dbo.LHBUs");
            DropForeignKey("dbo.TrDataLHBUs", "TransaksiId", "dbo.Transaksis");
            DropIndex("dbo.TrDataLHBUs", new[] { "TransaksiId" });
            DropIndex("dbo.TrDataLHBUs", new[] { "LHBU_Id" });
            AddColumn("dbo.TrDataLHBUs", "NamaFile", c => c.String());
            AddColumn("dbo.TrDataLHBUs", "Jenis", c => c.Int(nullable: false));
            AddColumn("dbo.TrDataLHBUs", "UploadFile", c => c.DateTime(nullable: false));
            AddColumn("dbo.TrDataLHBUs", "isDelete", c => c.Boolean(nullable: false));
            DropColumn("dbo.TrDataLHBUs", "TransaksiId");
            DropColumn("dbo.TrDataLHBUs", "DataLHBUId");
            DropColumn("dbo.TrDataLHBUs", "LHBU_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrDataLHBUs", "LHBU_Id", c => c.Int());
            AddColumn("dbo.TrDataLHBUs", "DataLHBUId", c => c.Int());
            AddColumn("dbo.TrDataLHBUs", "TransaksiId", c => c.Int());
            DropColumn("dbo.TrDataLHBUs", "isDelete");
            DropColumn("dbo.TrDataLHBUs", "UploadFile");
            DropColumn("dbo.TrDataLHBUs", "Jenis");
            DropColumn("dbo.TrDataLHBUs", "NamaFile");
            CreateIndex("dbo.TrDataLHBUs", "LHBU_Id");
            CreateIndex("dbo.TrDataLHBUs", "TransaksiId");
            AddForeignKey("dbo.TrDataLHBUs", "TransaksiId", "dbo.Transaksis", "Id");
            AddForeignKey("dbo.TrDataLHBUs", "LHBU_Id", "dbo.LHBUs", "Id");
        }
    }
}
