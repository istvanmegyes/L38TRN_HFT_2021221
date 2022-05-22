using L38TRN_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L38TRN_HFT_2021221.Endpoint.Services;
using Microsoft.AspNetCore.SignalR;

namespace L38TRN_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : Controller
    {
        IArtistLogic artistLogic;
        private readonly IHubContext<SignalRHub> hub;
        public NonCrudController(IArtistLogic artistLogic, IHubContext<SignalRHub> hub)
        {
            this.artistLogic = artistLogic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetNationalityCountOfArtists() 
        {
            return artistLogic.GetNationalityCountOfArtists();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> ArtistsMostExpensiveAlbum() 
        {
            return artistLogic.ArtistsMostExpensiveAlbum();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> ArtistsHighestSellingAlbum()
        {
            return artistLogic.ArtistsHighestSellingAlbum();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsByArtist()
        {
            return artistLogic.NumberOfAlbumsByArtist();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AverageSongDurationByArtists()
        {
            return artistLogic.AverageSongDurationByArtists();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfSongByArtist()
        {
            return artistLogic.NumberOfSongByArtist();
        }
    }
}
