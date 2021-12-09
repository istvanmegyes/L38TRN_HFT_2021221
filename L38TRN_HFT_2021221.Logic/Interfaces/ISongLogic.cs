using L38TRN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Logic
{
    public interface ISongLogic
    {
        void Create(Song song);
        Song Read(int id);
        void Update(Song song);
        void Delete(int id);
        IEnumerable<Song> ReadAll();
        IEnumerable<Song> MostListenedSongs();
        IEnumerable<Song> LeastListenedSongs();
    }
}
