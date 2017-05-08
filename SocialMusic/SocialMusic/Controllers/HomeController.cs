using SocialMusic.DBContexts;
using SocialMusic.Handlers;
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
        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            var authentificationHandler = new AuthentificationHandler(Session);

            User tempUser = new User();
            tempUser.Username = username;
            tempUser.Password = password;

            if (authentificationHandler.LogIn(tempUser))
            {
                return JavaScript("window.location = '/Profile/Index'");
            }
            return this.Json(new { success = false, message = "Log in failed!" });
        }
        [HttpPost]
        public ActionResult LogOut(User user)
        {
            var authentificationHandler = new AuthentificationHandler(Session);
            authentificationHandler.LogOut();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            var authentificationHandler = new AuthentificationHandler(Session);
            using (var db = new SocialMusicDbContext())
            {
                user.Created = DateTime.Now;

                
                user.Password = authentificationHandler.HashPassword(user.Password);
                

                db.Users.Add(user);

                db.SaveChanges();
            }
            return Redirect("Index");
        }
    }
}