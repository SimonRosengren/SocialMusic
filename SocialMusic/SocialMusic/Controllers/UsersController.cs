using SocialMusic.DBContexts;
using SocialMusic.Models;
using System.Linq;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            User[] users;
            using (var db = new SocialMusicDbContext())
            {
                users = db.Users.Take(100).ToArray();
            }

            return View(users);
        }
    }
}