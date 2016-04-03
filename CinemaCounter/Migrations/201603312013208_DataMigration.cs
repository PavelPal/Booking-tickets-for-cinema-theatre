using System.Data.Entity.Migrations;

namespace CinemaCounter.Migrations
{
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 100)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Scenes",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 100),
                    Description = c.String(false, 100),
                    DataOfCreated = c.DateTime(false),
                    Duration = c.Int(false),
                    Mark = c.Double(false),
                    ImagePath = c.String(),
                    Company_Id = c.Int(),
                    Director_Id = c.Int()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.Director_Id);

            CreateTable(
                "dbo.Cinemas",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 100),
                    Town = c.String(false, 100),
                    Street = c.String(false, 100),
                    Building = c.String(false, 10),
                    Station = c.String(),
                    WebSite = c.String(false, 100),
                    Phone = c.String(false),
                    ImagePath = c.String(),
                    Scene_Id = c.Int()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scenes", t => t.Scene_Id)
                .Index(t => t.Scene_Id);

            CreateTable(
                "dbo.Sessions",
                c => new
                {
                    Id = c.Int(false, true),
                    Date = c.DateTime(false),
                    Cinema_Id = c.Int(),
                    Scene_Id = c.Int()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id)
                .ForeignKey("dbo.Scenes", t => t.Scene_Id)
                .Index(t => t.Cinema_Id)
                .Index(t => t.Scene_Id);

            CreateTable(
                "dbo.Tickets",
                c => new
                {
                    Id = c.Int(false, true),
                    CustomerName = c.String(false, 100),
                    Cost = c.Decimal(false, 18, 2),
                    Session_Id = c.Int()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.Session_Id);

            CreateTable(
                "dbo.Companies",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 100)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Directors",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 100)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 100)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    Id = c.Int(false, true),
                    Title = c.String(false, 30),
                    Sender = c.String(false, 30),
                    Body = c.String(false, 100),
                    Date = c.DateTime(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(false, 128),
                    Name = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(false, 128),
                    RoleId = c.String(false, 128)
                })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Tasks",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(false, 100),
                    IsDone = c.Boolean(false),
                    IsImportant = c.Boolean(false),
                    Goal = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(false, 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(false),
                    TwoFactorEnabled = c.Boolean(false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(false),
                    AccessFailedCount = c.Int(false),
                    UserName = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(false, true),
                    UserId = c.String(false, 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(false, 128),
                    ProviderKey = c.String(false, 128),
                    UserId = c.String(false, 128)
                })
                .PrimaryKey(t => new {t.LoginProvider, t.ProviderKey, t.UserId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.SceneActors",
                c => new
                {
                    Scene_Id = c.Int(false),
                    Actor_Id = c.Int(false)
                })
                .PrimaryKey(t => new {t.Scene_Id, t.Actor_Id})
                .ForeignKey("dbo.Scenes", t => t.Scene_Id, true)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, true)
                .Index(t => t.Scene_Id)
                .Index(t => t.Actor_Id);

            CreateTable(
                "dbo.GenreScenes",
                c => new
                {
                    Genre_Id = c.Int(false),
                    Scene_Id = c.Int(false)
                })
                .PrimaryKey(t => new {t.Genre_Id, t.Scene_Id})
                .ForeignKey("dbo.Genres", t => t.Genre_Id, true)
                .ForeignKey("dbo.Scenes", t => t.Scene_Id, true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Scene_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.GenreScenes", "Scene_Id", "dbo.Scenes");
            DropForeignKey("dbo.GenreScenes", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Scenes", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.Scenes", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Cinemas", "Scene_Id", "dbo.Scenes");
            DropForeignKey("dbo.Tickets", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "Scene_Id", "dbo.Scenes");
            DropForeignKey("dbo.Sessions", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.SceneActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.SceneActors", "Scene_Id", "dbo.Scenes");
            DropIndex("dbo.GenreScenes", new[] {"Scene_Id"});
            DropIndex("dbo.GenreScenes", new[] {"Genre_Id"});
            DropIndex("dbo.SceneActors", new[] {"Actor_Id"});
            DropIndex("dbo.SceneActors", new[] {"Scene_Id"});
            DropIndex("dbo.AspNetUserLogins", new[] {"UserId"});
            DropIndex("dbo.AspNetUserClaims", new[] {"UserId"});
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] {"RoleId"});
            DropIndex("dbo.AspNetUserRoles", new[] {"UserId"});
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tickets", new[] {"Session_Id"});
            DropIndex("dbo.Sessions", new[] {"Scene_Id"});
            DropIndex("dbo.Sessions", new[] {"Cinema_Id"});
            DropIndex("dbo.Cinemas", new[] {"Scene_Id"});
            DropIndex("dbo.Scenes", new[] {"Director_Id"});
            DropIndex("dbo.Scenes", new[] {"Company_Id"});
            DropTable("dbo.GenreScenes");
            DropTable("dbo.SceneActors");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tasks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.Genres");
            DropTable("dbo.Directors");
            DropTable("dbo.Companies");
            DropTable("dbo.Tickets");
            DropTable("dbo.Sessions");
            DropTable("dbo.Cinemas");
            DropTable("dbo.Scenes");
            DropTable("dbo.Actors");
        }
    }
}