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
            var username = "xzorcious";
            var albumUrl = "http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user=" + username + "&api_key=7d063e651df846f5a4c10e618858189e&format=json";
            var artistUrl = "http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=7d063e651df846f5a4c10e618858189e&format=json";
            int test = 0;
            Album[] albums = new Album[5];
            Artist[] artists = new Artist[5];

            using (var webClient = new System.Net.WebClient())
            {               
                if (test == 1)
                {
                    var json = webClient.DownloadString(albumUrl);
                    dynamic root = JObject.Parse(json);
                    for (int i = 0; i < albums.Length; i++)
                    {
                        albums[i] = new Album();
                        albums[i].Name = root.topalbums.album[i].name;
                        albums[i].Artist = root.topalbums.album[i].artist.name;                       
                    }
                }
                else
                {
                    var json = webClient.DownloadString(artistUrl);
                    dynamic root = JObject.Parse(json);
                    for (int i = 0; i < artists.Length; i++)
                    {
                        artists[i] = new Artist();
                        artists[i].Name = root.topartists.artist[i].name;
                    }
                }
                         
            }           

            return View(artists);
        }
    }
}