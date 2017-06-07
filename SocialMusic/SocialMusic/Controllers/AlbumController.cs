using SocialMusic.Handlers;
using SocialMusic.Models;
using System.Web.Mvc;

namespace SocialMusic.Controllers
{
    public class AlbumController : Controller
    {
        [ChildActionOnly]
        public ActionResult TopAlbumsAndArtists()
        {
            AuthentificationHandler authHandler = new AuthentificationHandler(Session);
            ArtistAlbumViewModel AAVM = new ArtistAlbumViewModel();
            LastFmApiHandler lastFmApiHandler = new LastFmApiHandler();

            AAVM.Albums = lastFmApiHandler.GetAlbum(authHandler.GetUser().LastFmUsername);
            AAVM.Artists = lastFmApiHandler.GetArtist(authHandler.GetUser().LastFmUsername);
                     
            return PartialView("/Views/Partials/_TopAlbumsAndArtists.cshtml", AAVM);        
        }
    }
}