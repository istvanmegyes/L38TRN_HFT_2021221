using L38TRN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public interface IArtistRepository : IRepository<Artist>
    {
        void CreateCar(Artist artist);

        // update
        void UpdatePrice(int id, int newPrice);
        void UpdateName(int id, string newName);

        // delete
        void Deletecar(int id);
    }
}
