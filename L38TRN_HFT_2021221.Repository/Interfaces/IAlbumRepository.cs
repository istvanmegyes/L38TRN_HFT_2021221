using L38TRN_HFT_2021221.Models;
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
        void UpdateAlbumPrice(int id, int newPrice);
        void Update(Album album);
        void DeleteAlbum(int id);
    }
}
