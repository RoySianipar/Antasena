namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changestring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DataAntasenas", "StatusId", "dbo.Status");
            DropForeignKey("dbo.LHBUs", "StatusId", "dbo.Status");
            DropIndex("dbo.DataAntasenas", new[] { "StatusId" });
            DropIndex("dbo.LHBUs", new[] { "StatusId" });
            AlterColumn("dbo.DataAntasenas", "StatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "idPelapor", c => c.String());
            AlterColumn("dbo.DataAntasenas", "periodeData", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "idPihakLawan", c => c.String());
            AlterColumn("dbo.DataAntasenas", "tanggalEfektif", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "tanggalAwalForward", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "tanggalValuta", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "tanggalJatuhTempo", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "nominalValutaDasar", c => c.String());
            AlterColumn("dbo.DataAntasenas", "baseRate", c => c.String());
            AlterColumn("dbo.DataAntasenas", "premiSwap", c => c.String());
            AlterColumn("dbo.DataAntasenas", "transaksiPihakAsing", c => c.String());
            AlterColumn("dbo.DataAntasenas", "nettingNomorReferensiTransaksiTerakhir", c => c.String());
            AlterColumn("dbo.DataAntasenas", "nettingVolume", c => c.String());
            AlterColumn("dbo.LHBUs", "StatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "idPelapor", c => c.String());
            AlterColumn("dbo.LHBUs", "periodeData", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "idPihakLawan", c => c.String());
            AlterColumn("dbo.LHBUs", "tanggalEfektif", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "tanggalAwalForward", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "tanggalValuta", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "tanggalJatuhTempo", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "nominalValutaDasar", c => c.String());
            AlterColumn("dbo.LHBUs", "baseRate", c => c.String());
            AlterColumn("dbo.LHBUs", "premiSwap", c => c.String());
            AlterColumn("dbo.LHBUs", "transaksiPihakAsing", c => c.String());
            AlterColumn("dbo.LHBUs", "nettingNomorReferensiTransaksiTerakhir", c => c.String());
            AlterColumn("dbo.LHBUs", "nettingVolume", c => c.String());
            CreateIndex("dbo.DataAntasenas", "StatusId");
            CreateIndex("dbo.LHBUs", "StatusId");
            AddForeignKey("dbo.DataAntasenas", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LHBUs", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LHBUs", "StatusId", "dbo.Status");
            DropForeignKey("dbo.DataAntasenas", "StatusId", "dbo.Status");
            DropIndex("dbo.LHBUs", new[] { "StatusId" });
            DropIndex("dbo.DataAntasenas", new[] { "StatusId" });
            AlterColumn("dbo.LHBUs", "nettingVolume", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "nettingNomorReferensiTransaksiTerakhir", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "transaksiPihakAsing", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "premiSwap", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "baseRate", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "nominalValutaDasar", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "tanggalJatuhTempo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LHBUs", "tanggalValuta", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LHBUs", "tanggalAwalForward", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LHBUs", "tanggalEfektif", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LHBUs", "idPihakLawan", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "periodeData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LHBUs", "idPelapor", c => c.Int(nullable: false));
            AlterColumn("dbo.LHBUs", "StatusId", c => c.Int());
            AlterColumn("dbo.DataAntasenas", "nettingVolume", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "nettingNomorReferensiTransaksiTerakhir", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "transaksiPihakAsing", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "premiSwap", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "baseRate", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "nominalValutaDasar", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "tanggalJatuhTempo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DataAntasenas", "tanggalValuta", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DataAntasenas", "tanggalAwalForward", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DataAntasenas", "tanggalEfektif", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DataAntasenas", "idPihakLawan", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "periodeData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DataAntasenas", "idPelapor", c => c.Int(nullable: false));
            AlterColumn("dbo.DataAntasenas", "StatusId", c => c.Int());
            CreateIndex("dbo.LHBUs", "StatusId");
            CreateIndex("dbo.DataAntasenas", "StatusId");
            AddForeignKey("dbo.LHBUs", "StatusId", "dbo.Status", "Id");
            AddForeignKey("dbo.DataAntasenas", "StatusId", "dbo.Status", "Id");
        }
    }
}
