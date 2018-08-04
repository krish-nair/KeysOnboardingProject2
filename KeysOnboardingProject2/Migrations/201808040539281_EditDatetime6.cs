namespace KeysOnboardingProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatetime6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductSolds", "DateSold", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSolds", "DateSold", c => c.DateTime(nullable: false));
        }
    }
}
