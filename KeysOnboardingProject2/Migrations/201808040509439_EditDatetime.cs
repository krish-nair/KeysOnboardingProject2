namespace KeysOnboardingProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSolds", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductSolds", "DateSold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSolds", "DateSold", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductSolds", "DateCreated");
        }
    }
}
