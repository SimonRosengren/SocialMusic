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
            var url = "http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user=ludderaket&api_key=7d063e651df846f5a4c10e618858189e&format=json";
            Album[] albums = new Album[5];
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url);
                dynamic root = JObject.Parse(json);
                for (int i = 0; i < albums.Length; i++)
                {
                    albums[i] = new Album();
                    albums[i].Name = root.topalbums.album[i].name;
                    albums[i].Artist = root.topalbums.album[i].artist.name;
                }              
            }           

            return View(albums);
        }
    }
}