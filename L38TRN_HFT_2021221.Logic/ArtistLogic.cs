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

        public IEnumerable<Artist> ReadAll()
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


        public IEnumerable<KeyValuePair<string, int>> GetNationalityCountOfArtists()
        {
            var q = from x in artistRepo.GetAll()
                    group x by (x.Nationality) into g
                    select new {
                        _Nationality = g.Key,
                        _Count = g.Count()
                    };

            var output = new List<KeyValuePair<string, int>>();

            foreach (var item in q)
            {
                output.Add(new KeyValuePair<string, int>(item._Nationality, item._Count));
            }

            return output;
        }
    }
}
