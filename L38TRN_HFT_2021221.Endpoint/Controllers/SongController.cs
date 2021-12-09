using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Endpoint
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
            return SongLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return SongLogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Song value)
        {
            SongLogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Song newSong)
        {
            SongLogic.Update(newSong);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SongLogic.Delete(id);
        }
    }
}
