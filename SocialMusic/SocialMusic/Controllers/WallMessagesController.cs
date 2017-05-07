using SocialMusic.DBContexts;
using SocialMusic.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class WallMessagesController : Controller
    {
        [ChildActionOnly]
        public ActionResult Messages()
        {
            WallMessage[] messages;
            using (var db = new SocialMusicDbContext())
            {
                messages = db.WallMessages.Take(100).ToArray();
            }

            return PartialView("_Messages", messages);
        }


        [HttpGet]
        public ActionResult PostToWall()
        {
            return View();
        }
        
        [HttpPost]
        public void PostToWall(string message)
        {
            
            WallMessage m = new WallMessage();
            using (var db = new SocialMusicDbContext())
            {
                m.Created = DateTime.Now;
                m.Message = message;

                db.WallMessages.Add(m);

                db.SaveChanges();
            }
        }
        
    }
}