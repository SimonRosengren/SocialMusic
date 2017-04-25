﻿using SocialMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class WallMessagesController : Controller
    {
        public ActionResult Index()
        {
            WallMessage[] messages;
            using (var db = new WallMessageDbContext())
            {
                messages = db.WallMessages.Take(100).ToArray();
            }

            return View(messages);
        }
    }
}