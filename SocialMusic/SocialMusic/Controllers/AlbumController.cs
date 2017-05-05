using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocialMusic.Handlers;
using SocialMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        [ChildActionOnly]
        public ActionResult TopAlbumsAndArtists()
        {
            string username = "ludderaket";
            ArtistAlbumViewModel AAVM = new ArtistAlbumViewModel();
            LastFmApiHandler lastFmApiHandler = new LastFmApiHandler();

            AAVM.Albums = lastFmApiHandler.GetAlbum(username);
            AAVM.Artists = lastFmApiHandler.GetArtist(username);
                     
            return PartialView("TopAlbumsAndArtists", AAVM);        
        }
    }
}