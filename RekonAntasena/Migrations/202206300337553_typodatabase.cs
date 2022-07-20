namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typodatabase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transaksis", name: "LHBU_Id", newName: "LHBUId");
            RenameIndex(table: "dbo.Transaksis", name: "IX_LHBU_Id", newName: "IX_LHBUId");
            DropColumn("dbo.Transaksis", "DataLhbuId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaksis", "DataLhbuId", c => c.Int());
            RenameIndex(table: "dbo.Transaksis", name: "IX_LHBUId", newName: "IX_LHBU_Id");
            RenameColumn(table: "dbo.Transaksis", name: "LHBUId", newName: "LHBU_Id");
        }
    }
}
