using L38TRN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Logic
{
    public interface IArtistLogic
    {
        void Create(Artist artist);
        Artist Read(int id);
        void Update(Artist artist);
        void Delete(int id);
        IEnumerable<Artist> ReadAll();
        IEnumerable<KeyValuePair<string, int>> GetNationalityCountOfArtists();
        IEnumerable<KeyValuePair<string, double>> ArtistsMostExpensiveAlbum();
        IEnumerable<KeyValuePair<string, int>> ArtistsHighestSellingAlbum();
        IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsByArtist();
        IEnumerable<KeyValuePair<string, double>> AverageSongDurationByArtists();
        IEnumerable<KeyValuePair<string, int>> NumberOfSongByArtist();
    }
}
