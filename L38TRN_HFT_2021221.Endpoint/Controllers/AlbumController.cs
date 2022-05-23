using L38TRN_HFT_2021221.Endpoint.Services;
using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic AlbumLogic;
        private readonly IHubContext<SignalRHub> hub;
        public AlbumController(IAlbumLogic AlbumLogic, IHubContext<SignalRHub> hub)
        {
            this.AlbumLogic = AlbumLogic;
            this.hub = hub;
        }

        // GET: /Album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return AlbumLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return AlbumLogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Album value)
        {
            AlbumLogic.Create(value);
            this.hub.Clients.All.SendAsync("AlbumCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Album newAlbum)
        {
            AlbumLogic.Update(newAlbum);
            this.hub.Clients.All.SendAsync("AlbumUpdated", newAlbum);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var albumToDelete = this.AlbumLogic.Read(id);
            this.hub.Clients.All.SendAsync("AlbumDeleted", albumToDelete);
            AlbumLogic.Delete(id);
        }
    }
}
