using SocialMusic.Handlers;
using SocialMusic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SocialMusic.Controllers
{
    public class AlbumApiController : ApiController
    {
        LastFmApiHandler LFAH = new LastFmApiHandler();

        [HttpGet]
        [Route("api/search/album")]
        public IHttpActionResult GetAlbum(string name)
        {
            Album[] albums = LFAH.SearchAlbum(name).ToArray();  

            return Ok(albums);
        }
    }
}
