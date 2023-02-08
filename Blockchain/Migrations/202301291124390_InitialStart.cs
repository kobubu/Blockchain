namespace Blockchain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                        Created = c.DateTime(nullable: false),
                        Hash = c.String(),
                        PreviousHash = c.String(),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blocks");
        }
    }
}
