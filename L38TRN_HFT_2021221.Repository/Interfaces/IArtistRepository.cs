using L38TRN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public interface IArtistRepository : IRepository<Artist>
    {
        void Create(Artist artist);
        void UpdateArtistNationality(int id, string newNationality);
        void UpdateArtistName(int id, string newName);
        void Update(int id, Artist artist);
        void DeleteArtist(int id);
    }
}
