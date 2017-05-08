using SocialMusic.Handlers;
using SocialMusic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SocialMusic.Controllers
{
    public class AlbumApiController : ApiController
    {
        new static LastFmApiHandler LFAH = new LastFmApiHandler();
        Album[] albums = LFAH.SearchAlbum("Coloring book").ToArray();

        public IEnumerable<Album> GetAllAlbums()
        {
            return albums;
        }

        public IHttpActionResult GetAlbum(string name)
        {
            var album = albums.FirstOrDefault((s) => s.Name == name);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }
    }
}
