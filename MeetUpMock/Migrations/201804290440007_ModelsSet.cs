namespace MeetUpMock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Tagline = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        AgeLimit = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CityID = c.Int(),
                        Attendee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .ForeignKey("dbo.Attendees", t => t.Attendee_ID)
                .Index(t => t.CityID)
                .Index(t => t.Attendee_ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Attendee_ID", "dbo.Attendees");
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropIndex("dbo.Events", new[] { "Attendee_ID" });
            DropIndex("dbo.Events", new[] { "CityID" });
            DropTable("dbo.Cities");
            DropTable("dbo.Events");
            DropTable("dbo.Attendees");
        }
    }
}
