namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProgrammingLanguage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgrammingLanguage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Friend", "ProgrammingLanguageId", c => c.Int());
            CreateIndex("dbo.Friend", "ProgrammingLanguageId");
            AddForeignKey("dbo.Friend", "ProgrammingLanguageId", "dbo.ProgrammingLanguage", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friend", "ProgrammingLanguageId", "dbo.ProgrammingLanguage");
            DropIndex("dbo.Friend", new[] { "ProgrammingLanguageId" });
            DropColumn("dbo.Friend", "ProgrammingLanguageId");
            DropTable("dbo.ProgrammingLanguage");
        }
    }
}
