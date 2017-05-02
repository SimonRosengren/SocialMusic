using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public ActionResult Index()
        {
            string username = "ludderaket";
            int test = 1;
            int listSize = 5;
            ArtistAlbumViewModel AAVM = new ArtistAlbumViewModel();
            
            AAVM.Albums = GetAlbum(username, listSize);           
            AAVM.Artists = GetArtist(username, listSize);
                     
            return View(AAVM);        
        }

        public List<Album> GetAlbum(string username, int listSize)
        {
            var albumUrl = "http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user=" + username + "&api_key=7d063e651df846f5a4c10e618858189e&format=json";
            List<Album> albums = new List<Album>();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(albumUrl);
                var lol = "hej";
                dynamic root = JObject.Parse(json);
                for (int i = 0; i < listSize; i++)
                {
                    albums.Add(new Album());
                    albums[i].Name = root.topalbums.album[i].name;
                    albums[i].Artist = root.topalbums.album[i].artist.name;
                }
                return albums;
            }
        }

        public List<Artist> GetArtist(string username, int listSize)
        {
            var artistUrl = "http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=7d063e651df846f5a4c10e618858189e&format=json";
            List<Artist> artists = new List<Artist>();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(artistUrl);
                dynamic root = JObject.Parse(json);
                for (int i = 0; i < listSize; i++)
                {
                    artists.Add(new Artist());
                    artists[i].Name = root.topartists.artist[i].name;

                }
                return artists;
            }
        }
    }
}