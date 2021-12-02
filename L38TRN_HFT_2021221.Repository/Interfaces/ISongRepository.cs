using L38TRN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public interface ISongRepository : IRepository<Song>
    {
        void Create(Song song);
        void UpdateSongDuration(int id, int newDuration);
        void UpdateSongName(int id, string newSongName);
        void DeleteSong(int id);
    }
}
