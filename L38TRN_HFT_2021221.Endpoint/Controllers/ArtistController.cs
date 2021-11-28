using L38TRN_HFT_2021221.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221
{
    public class ArtistController
    {
        [Route("[controller]")]
        [ApiController]
        public class ArtistController : ControllerBase
        {

            IArtistLogic artistLogic;

            public ArtistController(IArtistLogic artistLogic)
            {
                this.artistLogic = artistLogic;
            }



            // GET: /Artist
            [HttpGet]
            public IEnumerable<Artist> Get()
            {
                return artistLogic.GetAllArtists();
            }

            // GET /Artist/5
            [HttpGet("{id}")]
            public Artist Get(int id)
            {
                return artistLogic.GetArtistById(id);
            }

            // POST /Artist
            [HttpPost]
            public void Post([FromBody] Artist value)
            {
                artistLogic.AddNewArtist(value);
            }

            // PUT /Artist
            [HttpPut]
            public void Put([FromBody] Artist value)
            {
                artistLogic.UpdateArtist(value);
            }

            // DELETE /Artist/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                artistLogic.DeleteArtist(id);
            }
        }
    }
}
