namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblStationStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StationID = c.Int(nullable: false),
                        isOnline = c.Boolean(nullable: false),
                        EventDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblStationStatus");
        }
    }
}
