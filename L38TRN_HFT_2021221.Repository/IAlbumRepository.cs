using L38TRN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public interface IAlbumRepository : IRepository<Album>
    {
        void Create(Album album);
        void UpdateAlbumName(int id, string newAlbumName);
        void updateAlbumPrice(int id, int newPrice);
        void DeleteAlbum(int id);
    }
}
