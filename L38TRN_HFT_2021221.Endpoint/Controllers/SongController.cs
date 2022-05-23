using L38TRN_HFT_2021221.Endpoint.Services;
using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace L38TRN_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic SongLogic;
        private readonly IHubContext<SignalRHub> hub;

        public SongController(ISongLogic SongLogic, IHubContext<SignalRHub> hub)
        {
            this.SongLogic = SongLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("SongCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Song newSong)
        {
            SongLogic.Update(newSong);
            this.hub.Clients.All.SendAsync("SongUpdated", newSong);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var songToDelete = this.SongLogic.Read(id);
            SongLogic.Delete(id);
            this.hub.Clients.All.SendAsync("SongDeleted", songToDelete);
        }
    }
}
