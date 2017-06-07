using System;

namespace SocialMusic.Models
{
    public class WallMessage
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }
    }
}