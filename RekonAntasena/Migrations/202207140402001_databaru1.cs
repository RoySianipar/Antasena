namespace RekonAntasena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaru1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransaksiTsus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        statusId = c.Int(),
                        TsuAntasenaId = c.Int(),
                        TsuLHBUId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.statusId)
                .ForeignKey("dbo.TsuAntasenas", t => t.TsuAntasenaId)
                .ForeignKey("dbo.TsuLHBUs", t => t.TsuLHBUId)
                .Index(t => t.statusId)
                .Index(t => t.TsuAntasenaId)
                .Index(t => t.TsuLHBUId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransaksiTsus", "TsuLHBUId", "dbo.TsuLHBUs");
            DropForeignKey("dbo.TransaksiTsus", "TsuAntasenaId", "dbo.TsuAntasenas");
            DropForeignKey("dbo.TransaksiTsus", "statusId", "dbo.Status");
            DropIndex("dbo.TransaksiTsus", new[] { "TsuLHBUId" });
            DropIndex("dbo.TransaksiTsus", new[] { "TsuAntasenaId" });
            DropIndex("dbo.TransaksiTsus", new[] { "statusId" });
            DropTable("dbo.TransaksiTsus");
        }
    }
}
