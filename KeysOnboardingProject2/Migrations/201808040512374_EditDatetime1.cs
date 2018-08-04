namespace KeysOnboardingProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatetime1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSolds", "DateSold", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductSolds", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSolds", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductSolds", "DateSold");
        }
    }
}
