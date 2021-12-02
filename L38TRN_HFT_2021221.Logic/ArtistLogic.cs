using L38TRN_HFT_2021221.Models;
using L38TRN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        IArtistRepository artistRepo;


        public ArtistLogic(IArtistRepository repo)
        {
            this.artistRepo = repo;
        }

        public void Update(int id, string newName)
        {
            artistRepo.UpdateArtistName(id, newName);
        }

        public Artist Read(int id)
        {
            return artistRepo.GetOne(id);
        }

        public List<Artist> GetAll()
        {
            return artistRepo.GetAll().ToList();
        }

        public void Create(Artist artist)
        {
            artistRepo.Create(artist);
        }

        public void Delete(int id)
        {
            artistRepo.DeleteArtist(id);
        }

        public IEnumerable<Artist> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, Album>> AVGAlbumsByArtist()
        {
            throw new NotImplementedException();
        }
    }
}
