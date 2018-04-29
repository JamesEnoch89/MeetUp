namespace MeetUpMock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataToSeed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Attendee_ID", "dbo.Attendees");
            DropIndex("dbo.Events", new[] { "Attendee_ID" });
            CreateTable(
                "dbo.EventAttendees",
                c => new
                    {
                        Event_ID = c.Int(nullable: false),
                        Attendee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_ID, t.Attendee_ID })
                .ForeignKey("dbo.Events", t => t.Event_ID, cascadeDelete: true)
                .ForeignKey("dbo.Attendees", t => t.Attendee_ID, cascadeDelete: true)
                .Index(t => t.Event_ID)
                .Index(t => t.Attendee_ID);
            
            DropColumn("dbo.Events", "Attendee_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Attendee_ID", c => c.Int());
            DropForeignKey("dbo.EventAttendees", "Attendee_ID", "dbo.Attendees");
            DropForeignKey("dbo.EventAttendees", "Event_ID", "dbo.Events");
            DropIndex("dbo.EventAttendees", new[] { "Attendee_ID" });
            DropIndex("dbo.EventAttendees", new[] { "Event_ID" });
            DropTable("dbo.EventAttendees");
            CreateIndex("dbo.Events", "Attendee_ID");
            AddForeignKey("dbo.Events", "Attendee_ID", "dbo.Attendees", "ID");
        }
    }
}
