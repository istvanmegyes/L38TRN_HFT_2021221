using L38TRN_HFT_2021221.Data;
using L38TRN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Logic
{
    public class ArtistLogic
    {
        IArtistRepository artistRepo;
        public ArtistLogic()
        {
            artistRepo = new ArtistRepository(new ProjectDbContext());
        }

        public ArtistLogic(IArtistRepository repo)
        {
            this.artistRepo = repo;
        }

        // --------------------------------------------------------------------------------------------------------

        public void ChangeArtistName(int id, string newName)
        {
            artistRepo.UpdateArtistName(id, newName);
        }

        public Artist GetOneArtist(int id)
        {
            return artistRepo.GetOne(id);
        }

        public List<Artist> GetAll()
        {
            return artistRepo.GetAll().ToList();
        }

        public void InsertCar(Artist artist)
        {
            artistRepo.CreateArtist(artist);
        }

        public void DeleteArtistById(int id)
        {
            artistRepo.DeleteArtistById(id);
        }
    }
}
