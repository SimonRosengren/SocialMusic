using Newtonsoft.Json.Linq;
using SocialMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMusic.Handlers
{
    public class LastFmApiHandler
    {
        const int LIST_SIZE = 5;
        //const string DOMAIN = ";
        const string API_KEY = "7d063e651df846f5a4c10e618858189e";
        const string URL = "http://ws.audioscrobbler.com/2.0/?method={0}&user={1}&api_key={2}&format=json";
        public LastFmApiHandler(string username)
        {
            GetAlbum(username);
            GetArtist(username);
        }

        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }

        private void GetAlbum(string username)
        {
            List<Album> albums = new List<Album>();
            dynamic root = DownloadData(String.Format(URL, "user.gettopalbums", username, API_KEY));
            for (int i = 0; i < LIST_SIZE; i++)
            {
                albums.Add(new Album());
                albums[i].Name = root.topalbums.album[i].name;
                albums[i].Artist = root.topalbums.album[i].artist.name;
            }
            Albums = albums;
        }

        private void GetArtist(string username)
        {
            List<Artist> artists = new List<Artist>();
            dynamic root = DownloadData(String.Format(URL, "user.gettopartists", username, API_KEY));
            for (int i = 0; i < LIST_SIZE; i++)
            {
                artists.Add(new Artist());
                artists[i].Name = root.topartists.artist[i].name;
            }
            Artists = artists;
        }

        private dynamic DownloadData(string url)
        {
            using (var WebClient = new System.Net.WebClient())
            {
                var json = WebClient.DownloadString(url);
                dynamic root = JObject.Parse(json);
                return root;
            }          
        }
    }
}