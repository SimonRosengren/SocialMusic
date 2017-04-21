using SocialMusic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SocialMusic.Controllers
{
    public class AlbumController : ApiController
    {
        Album[] albums = new Album[]
        {
            new Album {ID = 1, Name = "Coloring Book", Artist = "Chance the rapper"  },
            new Album {ID = 2, Name = "Starboy", Artist = "The Weeknd" },
            new Album {ID = 3, Name = "DAMN.", Artist = "Kendrick Lamar" }
        };

        public IEnumerable<Album> GetAllAlbums()
        {
            return albums;
        }

        public IHttpActionResult GetAlbum(int id)
        {
            var album = albums.FirstOrDefault((s) => s.ID == id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }
    }
}
