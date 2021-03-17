namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5177441c-4ab2-41ef-b8a8-47a2e2323e3e', N'admin@vidly.com', 0, N'AAS9mQbSH8lWtfCVlrLEY0wuQdgmo/zl093Q2pk2nNowy8fzQnDO6o81iWr/OIJXGw==', N'e09d16bc-fdb1-4b08-9c38-3b9da60c2119', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'becf8ec8-22c2-4217-97d4-dd2d1bb1f202', N'Guest@vidly.com', 0, N'AGTUrJsRBKGNKlj4Swo48UOiP+LMBJou7oDR1TSlKQYyD7UR+tOtMjXCAq/GMVtGNQ==', N'c95481b8-470a-4c50-8a18-51875e28c7f8', NULL, 0, 0, NULL, 1, 0, N'Guest@vidly.com')

INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'22d8d9f4-5658-48c0-981f-2adb6d7b382c', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5177441c-4ab2-41ef-b8a8-47a2e2323e3e', N'22d8d9f4-5658-48c0-981f-2adb6d7b382c')


"
);


        }
        
        public override void Down()
        {
        }
    }
}
