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
        void Update(int id, string newName);
        void Delete(int id);
        IEnumerable<Artist> ReadAll();
        IEnumerable<KeyValuePair<string, Album>> AVGAlbumsByArtist();
    }
}
