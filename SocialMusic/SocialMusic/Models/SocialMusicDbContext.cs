using SocialMusic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialMusic.DBContexts
{
    public class SocialMusicDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WallMessage> WallMessages { get; set; }
    }
}