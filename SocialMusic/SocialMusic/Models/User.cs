﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMusic.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
    }
}