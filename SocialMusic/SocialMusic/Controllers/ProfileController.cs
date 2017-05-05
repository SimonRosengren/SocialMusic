using SocialMusic.Attributes;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Returns the public profile of matching profile name
        /// </summary>
        public ActionResult PublicProfile(object name)
        {
            return View(name);
        }
    }
}