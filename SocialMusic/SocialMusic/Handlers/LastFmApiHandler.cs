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
        public LastFmApiHandler(string username)
        {
            GetAlbum(username);
            GetArtist(username);
        }

        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }

        private void GetAlbum(string username)
        {
            var albumUrl = "http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user=" + username + "&api_key=7d063e651df846f5a4c10e618858189e&format=json";
            List<Album> albums = new List<Album>();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(albumUrl);
                dynamic root = JObject.Parse(json);
                for (int i = 0; i < LIST_SIZE; i++)
                {
                    albums.Add(new Album());
                    albums[i].Name = root.topalbums.album[i].name;
                    albums[i].Artist = root.topalbums.album[i].artist.name;
                }
                Albums = albums;
            }
        }

        private void GetArtist(string username)
        {
            var artistUrl = "http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=7d063e651df846f5a4c10e618858189e&format=json";
            List<Artist> artists = new List<Artist>();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(artistUrl);
                dynamic root = JObject.Parse(json);
                for (int i = 0; i < LIST_SIZE; i++)
                {
                    artists.Add(new Artist());
                    artists[i].Name = root.topartists.artist[i].name;

                }
                Artists = artists;
            }
        }
    }
}