namespace Vidly_New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0450a58e-c93f-486d-97c1-fc3a5a971395', N'guest@gmail.com', 0, N'ACEBjFnvPMyGo8YZXtgSuaUVsxhxgM4qPtV4KWOwP4hWdeTS7uvI7ZjjT+atP1RtzA==', N'e05c4257-7a3f-4685-acd3-453d60a15691', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7aae71bd-aba6-4db0-ac4c-b319a6ff6fcf', N'admin@gmail.com', 0, N'AJf+tjBvBNFW7jwmGitm1UTuCjj92qk2lDQ05ZA9IC9als3YBorxOc0PRC/L0hmZ3A==', N'50d0bd4d-27ad-43ea-be83-8e43777dfcc9', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3c5cca1b-5322-4b7e-9f4f-aaa3be8d7742', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7aae71bd-aba6-4db0-ac4c-b319a6ff6fcf', N'3c5cca1b-5322-4b7e-9f4f-aaa3be8d7742')
");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
