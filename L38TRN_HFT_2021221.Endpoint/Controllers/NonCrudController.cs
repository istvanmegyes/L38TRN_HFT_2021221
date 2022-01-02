using L38TRN_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : Controller
    {
        IArtistLogic artistLogic;
        public NonCrudController(IArtistLogic artistLogic)
        {
            this.artistLogic = artistLogic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetNationalityCountOfArtists() 
        {
            return artistLogic.GetNationalityCountOfArtists();
        }

        public IEnumerable<KeyValuePair<string, double>> ArtistsMostExpensiveAlbum() 
        {
            return artistLogic.ArtistsMostExpensiveAlbum();
        }

        public IEnumerable<KeyValuePair<string, int>> ArtistsHighestSellingAlbum()
        {
            return artistLogic.ArtistsHighestSellingAlbum();
        }

        public IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsByArtist()
        {
            return artistLogic.NumberOfAlbumsByArtist();
        }

        public IEnumerable<KeyValuePair<string, double>> AverageSongDurationByArtists()
        {
            return artistLogic.AverageSongDurationByArtists();
        }

        public IEnumerable<KeyValuePair<string, int>> NumberOfSongByArtist()
        {
            return artistLogic.NumberOfSongByArtist();
        }
    }
}
