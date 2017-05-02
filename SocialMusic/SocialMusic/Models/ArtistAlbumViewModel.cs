using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMusic.Models
{
    public class ArtistAlbumViewModel
    {
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }
    }
}