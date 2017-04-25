using Newtonsoft.Json;
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
            Album album = new Album();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url);
                Album a = JsonConvert.DeserializeObject<Album>(json);
                album.Name = a.Name;
                album.Name = json;
            }
            

            return View(album);
        }
    }
}