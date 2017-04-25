using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialMusic.Models
{
    public class WallMessage
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }
    }

    public class WallMessageDbContext : DbContext
    {
        public DbSet<WallMessage> WallMessages { get; set; }
    }
}