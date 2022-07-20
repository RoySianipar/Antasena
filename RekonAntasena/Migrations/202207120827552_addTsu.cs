namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTsu : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TsuLHBUs", "StatusId", "dbo.Status");
            DropForeignKey("dbo.TsuAntasenas", "StatusId", "dbo.Status");
            DropIndex("dbo.TsuLHBUs", new[] { "StatusId" });
            DropIndex("dbo.TsuAntasenas", new[] { "StatusId" });
            DropTable("dbo.TsuLHBUs");
            DropTable("dbo.TsuAntasenas");
        }
    }
}
