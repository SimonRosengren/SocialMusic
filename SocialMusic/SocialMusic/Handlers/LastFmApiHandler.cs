﻿using Newtonsoft.Json.Linq;
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
        const string DOMAIN = "http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums";
        const string API_KEY = "7d063e651df846f5a4c10e618858189e";
        public LastFmApiHandler(string username)
        {
            GetAlbum(username);
            GetArtist(username);
        }

        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }

        private void GetAlbum(string username)
        {
            var albumUrl = DOMAIN + "&user=" + username + "&api_key=" + API_KEY + "&format=json";
            List<Album> albums = new List<Album>();
            dynamic root = DownloadData(albumUrl);
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
            var artistUrl = "http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=7d063e651df846f5a4c10e618858189e&format=json";
            List<Artist> artists = new List<Artist>();
            dynamic root = DownloadData(artistUrl);
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