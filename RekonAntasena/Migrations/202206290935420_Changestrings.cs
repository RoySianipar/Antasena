namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changestrings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DataAntasenas", "periodeData", c => c.String());
            AlterColumn("dbo.DataAntasenas", "tanggalEfektif", c => c.String());
            AlterColumn("dbo.DataAntasenas", "tanggalAwalForward", c => c.String());
            AlterColumn("dbo.DataAntasenas", "tanggalValuta", c => c.String());
            AlterColumn("dbo.DataAntasenas", "tanggalJatuhTempo", c => c.String());
            AlterColumn("dbo.LHBUs", "periodeData", c => c.String());
            AlterColumn("dbo.LHBUs", "tanggalEfektif", c => c.String());
            AlterColumn("dbo.LHBUs", "tanggalAwalForward", c => c.String());
            AlterColumn("dbo.LHBUs", "tanggalValuta", c => c.String());
            AlterColumn("dbo.LHBUs", "tanggalJatuhTempo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LHBUs", "tanggalJatuhTempo", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "tanggalValuta", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "tanggalAwalForward", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "tanggalEfektif", c => c.DateTime());
            AlterColumn("dbo.LHBUs", "periodeData", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "tanggalJatuhTempo", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "tanggalValuta", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "tanggalAwalForward", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "tanggalEfektif", c => c.DateTime());
            AlterColumn("dbo.DataAntasenas", "periodeData", c => c.DateTime());
        }
    }
}
