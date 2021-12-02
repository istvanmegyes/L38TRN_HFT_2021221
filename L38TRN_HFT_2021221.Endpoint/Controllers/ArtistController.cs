using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221
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

        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return artistLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            return artistLogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Artist value)
        {
            artistLogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] int id, string newName)
        {
            artistLogic.Update(id, newName);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            artistLogic.Delete(id);
        }
    }

}
