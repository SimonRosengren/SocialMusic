using Newtonsoft.Json.Linq;
using SocialMusic.Models;
using System;
using System.Collections.Generic;

namespace SocialMusic.Handlers
{
    public class LastFmApiHandler
    {
        const int LIST_SIZE = 5;
        const string API_KEY = "7d063e651df846f5a4c10e618858189e";
        const string URL = "http://ws.audioscrobbler.com/2.0/?method={0}&{1}={2}&api_key={3}&format=json";

        public LastFmApiHandler()
        {

        }

        public List<Album> SearchAlbum(string albumName)
        {
            List<Album> albums = new List<Album>();
            dynamic root = DownloadData(String.Format(URL, "album.search", "album", albumName, API_KEY));
            for (int i = 0; i < LIST_SIZE; i++)
            {
                albums.Add(new Album());
                albums[i].Name = root.results.albummatches.album[i].name;
                albums[i].Artist = root.results.albummatches.album[i].artist;
            }

            return albums;
        }

        public List<Album> GetAlbum(string username)
        {
            List<Album> albums = new List<Album>();
            dynamic root = DownloadData(String.Format(URL, "user.gettopalbums", "user", username, API_KEY));
            for (int i = 0; i < LIST_SIZE; i++)
            {
                albums.Add(new Album());
                albums[i].Name = root.topalbums.album[i].name;
                albums[i].Artist = root.topalbums.album[i].artist.name;
            }

            return albums;
        }

        public List<Artist> GetArtist(string username)
        {
            List<Artist> artists = new List<Artist>();
            dynamic root = DownloadData(String.Format(URL, "user.gettopartists", "user", username, API_KEY));
            for (int i = 0; i < LIST_SIZE; i++)
            {
                artists.Add(new Artist());
                artists[i].Name = root.topartists.artist[i].name;
            }
            return artists;
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