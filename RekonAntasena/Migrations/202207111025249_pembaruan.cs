namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pembaruan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TsuAntasenas", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Transaksis", "TsuAntasenaId", "dbo.TsuAntasenas");
            DropForeignKey("dbo.TsuLHBUs", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Transaksis", "TsuLHBUId", "dbo.TsuLHBUs");
            DropIndex("dbo.Transaksis", new[] { "TsuAntasenaId" });
            DropIndex("dbo.Transaksis", new[] { "TsuLHBUId" });
            DropIndex("dbo.TsuAntasenas", new[] { "StatusId" });
            DropIndex("dbo.TsuLHBUs", new[] { "StatusId" });
            DropColumn("dbo.Transaksis", "TsuAntasenaId");
            DropColumn("dbo.Transaksis", "TsuLHBUId");
            DropTable("dbo.TsuAntasenas");
            DropTable("dbo.TsuLHBUs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TsuLHBUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(nullable: false),
                        idPelapor = c.String(),
                        periodeLaporan = c.String(),
                        periodeData = c.String(),
                        nomorRefTransaksi = c.String(),
                        underlyingTransaksi = c.String(),
                        nominalValutaDasarPerUnderlying = c.String(),
                        jnsDokumenUnderlying = c.String(),
                        keteranganJnsDokumenUnderlying = c.String(),
                        nomorDokumenUnderlying = c.String(),
                        nominalDokumenUnderlying = c.String(),
                        valutaDokumenUnderlying = c.String(),
                        tanggalJatuhTempoDokumenUnderlying = c.String(),
                        isDelete = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TsuAntasenas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(nullable: false),
                        idPelapor = c.String(),
                        periodeLaporan = c.String(),
                        periodeData = c.String(),
                        nomorRefTransaksi = c.String(),
                        underlyingTransaksi = c.String(),
                        nominalValutaDasarPerUnderlying = c.String(),
                        jnsDokumenUnderlying = c.String(),
                        keteranganJnsDokumenUnderlying = c.String(),
                        nomorDokumenUnderlying = c.String(),
                        nominalDokumenUnderlying = c.String(),
                        valutaDokumenUnderlying = c.String(),
                        tanggalJatuhTempoDokumenUnderlying = c.String(),
                        isDelete = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transaksis", "TsuLHBUId", c => c.Int());
            AddColumn("dbo.Transaksis", "TsuAntasenaId", c => c.Int());
            CreateIndex("dbo.TsuLHBUs", "StatusId");
            CreateIndex("dbo.TsuAntasenas", "StatusId");
            CreateIndex("dbo.Transaksis", "TsuLHBUId");
            CreateIndex("dbo.Transaksis", "TsuAntasenaId");
            AddForeignKey("dbo.Transaksis", "TsuLHBUId", "dbo.TsuLHBUs", "Id");
            AddForeignKey("dbo.TsuLHBUs", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaksis", "TsuAntasenaId", "dbo.TsuAntasenas", "Id");
            AddForeignKey("dbo.TsuAntasenas", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }
    }
}
