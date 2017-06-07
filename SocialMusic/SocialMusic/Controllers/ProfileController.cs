using SocialMusic.Attributes;
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