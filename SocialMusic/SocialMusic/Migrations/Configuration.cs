namespace SocialMusic.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialMusic.Models.UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SocialMusic.Models.UserDbContext";
        }

        protected override void Seed(SocialMusic.Models.UserDbContext context)
        {
            context.Users.AddOrUpdate(i => i.Username,
                new User
                {
                    Username = "Simon",
                    Password = "12345",
                    LastFmUsername = "xzorcious",
                    Created = DateTime.Now 

                },

                new User
                {
                     Username = "Ludde",
                     Password = "12345",
                     LastFmUsername = "LuddeRaket",
                     Created = DateTime.Now

                }
           );
        }
    }
}
