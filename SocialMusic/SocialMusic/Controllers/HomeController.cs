using SocialMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            using (var db = new UserDbContext())
            {
                user.Created = DateTime.Now;
                

                db.Users.Add(user);
                db.SaveChanges();
            }
            return Redirect("Index");
        }
    }
}