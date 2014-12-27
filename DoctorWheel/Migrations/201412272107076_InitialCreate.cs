namespace DoctorWheel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        LicensePlate = c.String(),
                        Color = c.String(),
                        InService = c.Boolean(nullable: false),
                        ToSell = c.Boolean(nullable: false),
                        FaultName = c.String(),
                        RepairPrecentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Double(nullable: false),
                        IsOrdered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        IsIndebted = c.Boolean(nullable: false),
                        Debt = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TownName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shop", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Service", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Car", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Car", "ClientID", "dbo.Client");
            DropIndex("dbo.Shop", new[] { "DepartmentID" });
            DropIndex("dbo.Service", new[] { "DepartmentID" });
            DropIndex("dbo.Car", new[] { "ClientID" });
            DropIndex("dbo.Car", new[] { "DepartmentID" });
            DropTable("dbo.Shop");
            DropTable("dbo.Service");
            DropTable("dbo.Department");
            DropTable("dbo.Client");
            DropTable("dbo.Car");
        }
    }
}
