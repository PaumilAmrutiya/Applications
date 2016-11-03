namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            //test
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Parent1FirstName = c.String(),
                        Parent1LastName = c.String(),
                        Parent2FirstName = c.String(),
                        Parent2LastName = c.String(),
                        Address = c.String(),
                        SuburbId = c.Int(nullable: false),
                        Phone = c.String(),
                        Mobile = c.String(),
                        FamilyId = c.Int(nullable: false),
                        OraganisationId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oraganisations", t => t.OraganisationId)
                .ForeignKey("dbo.Suburbs", t => t.SuburbId)
                .Index(t => t.SuburbId)
                .Index(t => t.OraganisationId);
            
            CreateTable(
                "dbo.Oraganisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EducatorName = c.String(),
                        RegistrationNumber = c.Int(nullable: false),
                        WwcNumber = c.Int(nullable: false),
                        Address = c.String(),
                        SuburbId = c.Int(nullable: false),
                        Phone = c.String(),
                        Mobile = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suburbs", t => t.SuburbId)
                .Index(t => t.SuburbId);
            
            CreateTable(
                "dbo.Suburbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostCode = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OraganisationId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oraganisations", t => t.OraganisationId)
                .Index(t => t.OraganisationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "OraganisationId", "dbo.Oraganisations");
            DropForeignKey("dbo.Suburbs", "StateId", "dbo.States");
            DropForeignKey("dbo.Oraganisations", "SuburbId", "dbo.Suburbs");
            DropForeignKey("dbo.Children", "SuburbId", "dbo.Suburbs");
            DropForeignKey("dbo.Children", "OraganisationId", "dbo.Oraganisations");
            DropIndex("dbo.Users", new[] { "OraganisationId" });
            DropIndex("dbo.Suburbs", new[] { "StateId" });
            DropIndex("dbo.Oraganisations", new[] { "SuburbId" });
            DropIndex("dbo.Children", new[] { "OraganisationId" });
            DropIndex("dbo.Children", new[] { "SuburbId" });
            DropTable("dbo.Users");
            DropTable("dbo.States");
            DropTable("dbo.Suburbs");
            DropTable("dbo.Oraganisations");
            DropTable("dbo.Children");
        }
    }
}
