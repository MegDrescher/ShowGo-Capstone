namespace ShowGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArtistId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        ChoiceId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ChoiceId);
            
            CreateTable(
                "dbo.Concertgoers",
                c => new
                    {
                        ConcertgoerId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConcertgoerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        ConcertId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConcertId)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        text = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.RecommendedResults",
                c => new
                    {
                        RecommendedResultId = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        ChoiceId = c.Int(nullable: false),
                        ConcertgoerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecommendedResultId)
                .ForeignKey("dbo.Choices", t => t.ChoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Concertgoers", t => t.ConcertgoerId, cascadeDelete: true)
                .Index(t => t.ChoiceId)
                .Index(t => t.ConcertgoerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        SurveyId = c.Int(nullable: false, identity: true),
                        SurveyTitle = c.String(),
                    })
                .PrimaryKey(t => t.SurveyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RecommendedResults", "ConcertgoerId", "dbo.Concertgoers");
            DropForeignKey("dbo.RecommendedResults", "ChoiceId", "dbo.Choices");
            DropForeignKey("dbo.Concerts", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Concertgoers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Artists", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Artists", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RecommendedResults", new[] { "ConcertgoerId" });
            DropIndex("dbo.RecommendedResults", new[] { "ChoiceId" });
            DropIndex("dbo.Concerts", new[] { "ArtistId" });
            DropIndex("dbo.Concertgoers", new[] { "ApplicationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Artists", new[] { "ApplicationId" });
            DropIndex("dbo.Artists", new[] { "GenreId" });
            DropTable("dbo.Surveys");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RecommendedResults");
            DropTable("dbo.Questions");
            DropTable("dbo.Concerts");
            DropTable("dbo.Concertgoers");
            DropTable("dbo.Choices");
            DropTable("dbo.Genres");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Artists");
        }
    }
}
