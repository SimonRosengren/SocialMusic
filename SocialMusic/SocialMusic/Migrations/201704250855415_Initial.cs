namespace SocialMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LastFmUsername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastFmUsername");
        }
    }
}
