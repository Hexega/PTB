namespace PTB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        Password = c.String(),
                        Server = c.String(),
                        Tribe = c.Int(nullable: false),
                        Speed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
