using L38TRN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Logic
{
    public interface IAlbumLogic
    {
        void Create(Album album);
        Album Read(int id);
        void Update(Album album);
        void Delete(int id);
        IEnumerable<Album> ReadAll();
        IEnumerable<Album> CheapAlbums();
        IEnumerable<Album> ExpensiveAlbums();
    }
}
