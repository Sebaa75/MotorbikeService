namespace MotorbikeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationStarted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        Suplier = c.String(),
                        Amount = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        PartsType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        Mileage = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceWorks");
            DropTable("dbo.Parts");
        }
    }
}
