using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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

        public AlbumController(IAlbumLogic AlbumLogic)
        {
            this.AlbumLogic = AlbumLogic;
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
        }

        [HttpPut]
        public void Put([FromBody] Album newAlbum)
        {
            AlbumLogic.Update(newAlbum);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AlbumLogic.Delete(id);
        }
    }
}
