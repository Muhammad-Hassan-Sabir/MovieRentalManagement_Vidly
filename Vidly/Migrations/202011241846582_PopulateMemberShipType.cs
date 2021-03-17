namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberShipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "DiscountRate", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "DicounteRate");

            Sql("INSERT INTO MembershipTypes (Id,Signupfree,DurationInMonths,DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id,Signupfree,DurationInMonths,DiscountRate) VALUES (2,30,1,10)");
            Sql("INSERT INTO MembershipTypes (Id,Signupfree,DurationInMonths,DiscountRate) VALUES (3,90,3,15)");
            Sql("INSERT INTO MembershipTypes (Id,Signupfree,DurationInMonths,DiscountRate) VALUES (4,300,12,20)");

        }

        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DicounteRate", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "DiscountRate");
        }
    }
}
