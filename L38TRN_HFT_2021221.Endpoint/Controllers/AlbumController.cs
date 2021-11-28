using L38TRN_HFT_2021221.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Endpoint.Controllers
{
    public class AlbumController
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
                return AlbumLogic.GetAllAlbums();
            }

            [HttpGet("{id}")]
            public Album Get(int id)
            {
                return AlbumLogic.GetAlbumById(id);
            }

            [HttpPost]
            public void Post([FromBody] Album value)
            {
                AlbumLogic.AddNewAlbum(value);
            }

            [HttpPut]
            public void Put([FromBody] Album value)
            {
                AlbumLogic.UpdateAlbum(value);
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                AlbumLogic.DeleteAlbum(id);
            }
        }
    }
}
