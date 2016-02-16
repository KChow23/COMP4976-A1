namespace OptionsWebSite.Migrations.DiplomaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDBCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        FirstChoiceOptionId = c.Int(),
                        SecondChoiceOptionId = c.Int(),
                        ThirdChoiceOptionId = c.Int(),
                        FourthChoiceOptionId = c.Int(),
                        ChoiceId = c.Int(nullable: false, identity: true),
                        YearTermId = c.Int(),
                        StudentId = c.String(maxLength: 9),
                        StudentFirstName = c.String(nullable: false, maxLength: 40),
                        StudentLastName = c.String(nullable: false, maxLength: 40),
                        SelectionDate = c.DateTime(nullable: false),
                        Option_OptionId = c.Int(),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.Options", t => t.Option_OptionId)
                .ForeignKey("dbo.Options", t => t.FirstChoiceOptionId)
                .ForeignKey("dbo.Options", t => t.FourthChoiceOptionId)
                .ForeignKey("dbo.Options", t => t.SecondChoiceOptionId)
                .ForeignKey("dbo.Options", t => t.ThirdChoiceOptionId)
                .ForeignKey("dbo.YearTerms", t => t.YearTermId)
                .Index(t => t.FirstChoiceOptionId, unique: true)
                .Index(t => t.SecondChoiceOptionId, unique: true)
                .Index(t => t.ThirdChoiceOptionId, unique: true)
                .Index(t => t.FourthChoiceOptionId, unique: true)
                .Index(t => t.YearTermId)
                .Index(t => t.Option_OptionId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OptionId);
            
            CreateTable(
                "dbo.YearTerms",
                c => new
                    {
                        YearTermId = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Term = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YearTermId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choices", "YearTermId", "dbo.YearTerms");
            DropForeignKey("dbo.Choices", "ThirdChoiceOptionId", "dbo.Options");
            DropForeignKey("dbo.Choices", "SecondChoiceOptionId", "dbo.Options");
            DropForeignKey("dbo.Choices", "FourthChoiceOptionId", "dbo.Options");
            DropForeignKey("dbo.Choices", "FirstChoiceOptionId", "dbo.Options");
            DropForeignKey("dbo.Choices", "Option_OptionId", "dbo.Options");
            DropIndex("dbo.Choices", new[] { "Option_OptionId" });
            DropIndex("dbo.Choices", new[] { "YearTermId" });
            DropIndex("dbo.Choices", new[] { "FourthChoiceOptionId" });
            DropIndex("dbo.Choices", new[] { "ThirdChoiceOptionId" });
            DropIndex("dbo.Choices", new[] { "SecondChoiceOptionId" });
            DropIndex("dbo.Choices", new[] { "FirstChoiceOptionId" });
            DropTable("dbo.YearTerms");
            DropTable("dbo.Options");
            DropTable("dbo.Choices");
        }
    }
}
