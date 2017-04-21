using SocialMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            User[] users;
            using (var db = new UserDbContext())
            {
                users = db.Users.Take(100).ToArray();
            }

            return View(users);
        }
    }
}