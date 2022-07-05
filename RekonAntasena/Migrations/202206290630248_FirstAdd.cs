namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataAntasenas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(),
                        idPelapor = c.Int(nullable: false),
                        periodeLaporan = c.String(),
                        periodeData = c.DateTime(nullable: false),
                        nomorRefTransaksi = c.String(),
                        idPihakLawan = c.Int(nullable: false),
                        kontrak = c.String(),
                        variabelMendasari = c.String(),
                        peranPelapor = c.String(),
                        jamTransaksi = c.DateTime(nullable: false),
                        tanggalEfektif = c.DateTime(nullable: false),
                        tanggalAwalForward = c.DateTime(nullable: false),
                        tanggalValuta = c.DateTime(nullable: false),
                        tanggalJatuhTempo = c.DateTime(nullable: false),
                        valutaDasar = c.String(),
                        valutaLawan = c.String(),
                        nominalValutaDasar = c.Int(nullable: false),
                        kursTransaksi = c.String(),
                        strikePrice2 = c.String(),
                        baseRate = c.Int(nullable: false),
                        premiSwap = c.Int(nullable: false),
                        premiOption = c.String(),
                        styleOption = c.String(),
                        periodePembayaranBunga = c.String(),
                        valutaDasarJnsSukuBunga = c.String(),
                        valutaDasarJnsSukuBungaAcuan = c.String(),
                        valutaDasarTenorSukuBungaAcuan = c.String(),
                        valutaDasarPremiumSukuBungaAcuan = c.String(),
                        valutaDasarSukuBungaTetap = c.String(),
                        valutaLawanJnsSukuBunga = c.String(),
                        valutaLawanJnsSukuBungaAcuan = c.String(),
                        valutaLawanTenorSukuBungaAcuan = c.String(),
                        valutaLawanPremiumSukuBungaAcuan = c.String(),
                        valutaLawanSukuBungaTetap = c.String(),
                        hargaFutures = c.String(),
                        keteranganTransaksi = c.String(),
                        transaksiPihakAsing = c.Int(nullable: false),
                        lcsNegaraMitra = c.String(),
                        nettingNomorReferensiTransaksiTerakhir = c.Int(nullable: false),
                        nettingTujuan = c.String(),
                        nettingVolume = c.Int(nullable: false),
                        dynamicHedgingNomorReferensiTransaksiTerakhir = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LHBUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(),
                        idPelapor = c.Int(nullable: false),
                        periodeLaporan = c.String(),
                        periodeData = c.DateTime(nullable: false),
                        nomorRefTransaksi = c.String(),
                        idPihakLawan = c.Int(nullable: false),
                        kontrak = c.String(),
                        variabelMendasari = c.String(),
                        peranPelapor = c.String(),
                        jamTransaksi = c.DateTime(nullable: false),
                        tanggalEfektif = c.DateTime(nullable: false),
                        tanggalAwalForward = c.DateTime(nullable: false),
                        tanggalValuta = c.DateTime(nullable: false),
                        tanggalJatuhTempo = c.DateTime(nullable: false),
                        valutaDasar = c.String(),
                        valutaLawan = c.String(),
                        nominalValutaDasar = c.Int(nullable: false),
                        kursTransaksi = c.String(),
                        strikePrice2 = c.String(),
                        baseRate = c.Int(nullable: false),
                        premiSwap = c.Int(nullable: false),
                        premiOption = c.String(),
                        styleOption = c.String(),
                        periodePembayaranBunga = c.String(),
                        valutaDasarJnsSukuBunga = c.String(),
                        valutaDasarJnsSukuBungaAcuan = c.String(),
                        valutaDasarTenorSukuBungaAcuan = c.String(),
                        valutaDasarPremiumSukuBungaAcuan = c.String(),
                        valutaDasarSukuBungaTetap = c.String(),
                        valutaLawanJnsSukuBunga = c.String(),
                        valutaLawanJnsSukuBungaAcuan = c.String(),
                        valutaLawanTenorSukuBungaAcuan = c.String(),
                        valutaLawanPremiumSukuBungaAcuan = c.String(),
                        valutaLawanSukuBungaTetap = c.String(),
                        hargaFutures = c.String(),
                        keteranganTransaksi = c.String(),
                        transaksiPihakAsing = c.Int(nullable: false),
                        lcsNegaraMitra = c.String(),
                        nettingNomorReferensiTransaksiTerakhir = c.Int(nullable: false),
                        nettingTujuan = c.String(),
                        nettingVolume = c.Int(nullable: false),
                        dynamicHedgingNomorReferensiTransaksiTerakhir = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Transaksis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        statusId = c.Int(),
                        DataAntasenaId = c.Int(),
                        DataLhbuId = c.Int(),
                        LHBU_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataAntasenas", t => t.DataAntasenaId)
                .ForeignKey("dbo.LHBUs", t => t.LHBU_Id)
                .ForeignKey("dbo.Status", t => t.statusId)
                .Index(t => t.statusId)
                .Index(t => t.DataAntasenaId)
                .Index(t => t.LHBU_Id);
            
            CreateTable(
                "dbo.TrDataAntasenas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransaksiId = c.Int(),
                        DataAntasenaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataAntasenas", t => t.DataAntasenaId)
                .ForeignKey("dbo.Transaksis", t => t.TransaksiId)
                .Index(t => t.TransaksiId)
                .Index(t => t.DataAntasenaId);
            
            CreateTable(
                "dbo.TrDataLHBUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransaksiId = c.Int(),
                        DataLHBUId = c.Int(),
                        LHBU_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LHBUs", t => t.LHBU_Id)
                .ForeignKey("dbo.Transaksis", t => t.TransaksiId)
                .Index(t => t.TransaksiId)
                .Index(t => t.LHBU_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrDataLHBUs", "TransaksiId", "dbo.Transaksis");
            DropForeignKey("dbo.TrDataLHBUs", "LHBU_Id", "dbo.LHBUs");
            DropForeignKey("dbo.TrDataAntasenas", "TransaksiId", "dbo.Transaksis");
            DropForeignKey("dbo.TrDataAntasenas", "DataAntasenaId", "dbo.DataAntasenas");
            DropForeignKey("dbo.Transaksis", "statusId", "dbo.Status");
            DropForeignKey("dbo.Transaksis", "LHBU_Id", "dbo.LHBUs");
            DropForeignKey("dbo.Transaksis", "DataAntasenaId", "dbo.DataAntasenas");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LHBUs", "StatusId", "dbo.Status");
            DropForeignKey("dbo.DataAntasenas", "StatusId", "dbo.Status");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TrDataLHBUs", new[] { "LHBU_Id" });
            DropIndex("dbo.TrDataLHBUs", new[] { "TransaksiId" });
            DropIndex("dbo.TrDataAntasenas", new[] { "DataAntasenaId" });
            DropIndex("dbo.TrDataAntasenas", new[] { "TransaksiId" });
            DropIndex("dbo.Transaksis", new[] { "LHBU_Id" });
            DropIndex("dbo.Transaksis", new[] { "DataAntasenaId" });
            DropIndex("dbo.Transaksis", new[] { "statusId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LHBUs", new[] { "StatusId" });
            DropIndex("dbo.DataAntasenas", new[] { "StatusId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TrDataLHBUs");
            DropTable("dbo.TrDataAntasenas");
            DropTable("dbo.Transaksis");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LHBUs");
            DropTable("dbo.Status");
            DropTable("dbo.DataAntasenas");
        }
    }
}
