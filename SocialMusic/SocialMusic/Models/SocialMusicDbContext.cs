using SocialMusic.Models;
using System.Data.Entity;

namespace SocialMusic.DBContexts
{
    public class SocialMusicDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WallMessage> WallMessages { get; set; }
    }
}