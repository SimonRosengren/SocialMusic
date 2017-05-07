using SocialMusic.Attributes;
using SocialMusic.DBContexts;
using SocialMusic.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class ProfileController : Controller
    {
        [Authenticate(View = "NotAuthenticated")]
        public ActionResult Index()
        {
            return View();
        }
    }
}