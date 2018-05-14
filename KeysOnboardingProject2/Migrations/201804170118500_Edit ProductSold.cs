namespace KeysOnboardingProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProductSold : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSolds", "DateSold", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSolds", "DateSold");
        }
    }
}
