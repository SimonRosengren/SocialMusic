﻿using System;

namespace SocialMusic.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastFmUsername { get; set; }
        public DateTime Created { get; set; }
    }   
}