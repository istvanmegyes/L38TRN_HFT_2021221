using L38TRN_HFT_2021221.Endpoint.Services;
using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<SignalRHub> hub;
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
            this.hub.Clients.All.SendAsync("ArtistCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Artist newArtist)
        {
            artistLogic.Update(newArtist);
            this.hub.Clients.All.SendAsync("ArtistUpdated", newArtist);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            artistLogic.Delete(id);
            var artistToDelete = this.artistLogic.Read(id);
            this.hub.Clients.All.SendAsync("ArtistDeleted", artistToDelete);
        }
    }

}
