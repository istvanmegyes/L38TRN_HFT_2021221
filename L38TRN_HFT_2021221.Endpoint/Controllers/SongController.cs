using L38TRN_HFT_2021221.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Endpoint
{
    public class SongController
    {
        [Route("[controller]")]
        [ApiController]
        public class SongController : ControllerBase
        {
            ISongLogic SongLogic;

            public SongController(ISongLogic SongLogic)
            {
                this.SongLogic = SongLogic;
            }

            // GET: /Song
            [HttpGet]
            public IEnumerable<Song> Get()
            {
                return SongLogic.GetAllSongs();
            }

            [HttpGet("{id}")]
            public Song Get(int id)
            {
                return SongLogic.GetSongById(id);
            }

            [HttpPost]
            public void Post([FromBody] Song value)
            {
                SongLogic.AddNewSong(value);
            }

            [HttpPut]
            public void Put([FromBody] Song value)
            {
                SongLogic.UpdateSong(value);
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                SongLogic.DeleteSong(id);
            }
        }
    }
}
