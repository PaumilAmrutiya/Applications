namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewFieldsandTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "OraganisationId", "dbo.Oraganisations");
            DropIndex("dbo.Users", new[] { "OraganisationId" });
            CreateTable(
                "dbo.ChildFrequencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tuesday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Wednesday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Thursday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Friday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Saturday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sunday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChildId = c.Int(nullable: false),
                        FrequencyTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Children", t => t.ChildId)
                .ForeignKey("dbo.FrequencyTypes", t => t.FrequencyTypeId)
                .Index(t => t.ChildId)
                .Index(t => t.FrequencyTypeId);
            
            CreateTable(
                "dbo.FrequencyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Children", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Children", "Casual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Children", "CentrelinkMethods", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Children", "CcbPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Oraganisations", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Oraganisations", "StartOfWeekDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "EmailAddress", c => c.String());
            AddColumn("dbo.Users", "UserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Oraganisations", "UserId");
            AddForeignKey("dbo.Oraganisations", "UserId", "dbo.Users", "Id");
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "OraganisationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "OraganisationId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "UserName", c => c.String());
            DropForeignKey("dbo.Oraganisations", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChildFrequencies", "FrequencyTypeId", "dbo.FrequencyTypes");
            DropForeignKey("dbo.ChildFrequencies", "ChildId", "dbo.Children");
            DropIndex("dbo.Oraganisations", new[] { "UserId" });
            DropIndex("dbo.ChildFrequencies", new[] { "FrequencyTypeId" });
            DropIndex("dbo.ChildFrequencies", new[] { "ChildId" });
            DropColumn("dbo.Users", "UserTypeId");
            DropColumn("dbo.Users", "EmailAddress");
            DropColumn("dbo.Oraganisations", "StartOfWeekDate");
            DropColumn("dbo.Oraganisations", "UserId");
            DropColumn("dbo.Children", "CcbPercentage");
            DropColumn("dbo.Children", "CentrelinkMethods");
            DropColumn("dbo.Children", "Casual");
            DropColumn("dbo.Children", "StartDate");
            DropTable("dbo.FrequencyTypes");
            DropTable("dbo.ChildFrequencies");
            CreateIndex("dbo.Users", "OraganisationId");
            AddForeignKey("dbo.Users", "OraganisationId", "dbo.Oraganisations", "Id");
        }
    }
}
