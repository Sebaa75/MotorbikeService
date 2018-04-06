namespace MotorbikeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationStarted1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotorBikeServiceWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MotorBikeId = c.Int(nullable: false),
                        ServiceWorkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MotorBikes", t => t.MotorBikeId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceWorks", t => t.ServiceWorkId, cascadeDelete: true)
                .Index(t => t.MotorBikeId)
                .Index(t => t.ServiceWorkId);
            
            CreateTable(
                "dbo.PartsWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartsId = c.Int(nullable: false),
                        ServiceWorkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartsId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceWorks", t => t.ServiceWorkId, cascadeDelete: true)
                .Index(t => t.PartsId)
                .Index(t => t.ServiceWorkId);
            
            AddColumn("dbo.ServiceWorks", "MotorBike_Id", c => c.Int());
            CreateIndex("dbo.ServiceWorks", "MotorBike_Id");
            AddForeignKey("dbo.ServiceWorks", "MotorBike_Id", "dbo.MotorBikes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceWorks", "MotorBike_Id", "dbo.MotorBikes");
            DropForeignKey("dbo.PartsWorks", "ServiceWorkId", "dbo.ServiceWorks");
            DropForeignKey("dbo.PartsWorks", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.MotorBikeServiceWorks", "ServiceWorkId", "dbo.ServiceWorks");
            DropForeignKey("dbo.MotorBikeServiceWorks", "MotorBikeId", "dbo.MotorBikes");
            DropIndex("dbo.PartsWorks", new[] { "ServiceWorkId" });
            DropIndex("dbo.PartsWorks", new[] { "PartsId" });
            DropIndex("dbo.MotorBikeServiceWorks", new[] { "ServiceWorkId" });
            DropIndex("dbo.MotorBikeServiceWorks", new[] { "MotorBikeId" });
            DropIndex("dbo.ServiceWorks", new[] { "MotorBike_Id" });
            DropColumn("dbo.ServiceWorks", "MotorBike_Id");
            DropTable("dbo.PartsWorks");
            DropTable("dbo.MotorBikeServiceWorks");
        }
    }
}
