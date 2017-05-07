using SocialMusic.DBContexts;
using SocialMusic.Models;
using System.Linq;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class PublicProfileController : Controller
    {
        /// <summary>
        /// Returns the public profile of matching profile name
        /// </summary>
        public ActionResult Index(object name)
        {
            User user = new User();
            using (var db = new SocialMusicDbContext())
            {
                user = db.Users.FirstOrDefault(s => s.Username == (string)name);
            }
            if (user == null)
            {
                return RedirectToAction("Index", "Users");
            }
            return View(user);
        }
    }
}