using L38TRN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public class ArtistRepository : IRepository<Artist>
    {
        public ArtistRepository(ProjectDbContext projectDbContext) : base(projectDbContext) { }

        public override Artist GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ArtistID == id);
        }

        public void UpdateArtistName(int id, string newName)
        {
            var Artist = GetOne(id);
            Artist.ArtistName = newName;

            projectDbContext.SaveChanges();
        }

        public void AddNewArtist(Artist Artist)
        {
            projectDbContext.Add(Artist);
            projectDbContext.SaveChanges();
        }

        public void DeleteArtistById(int id)
        {
            var toDelete = GetOne(id);
            projectDbContext.Remove(toDelete);
            projectDbContext.SaveChanges();
        }

        public void UpdateArtist(Artist Artist)
        {
            var toUpdate = GetOne(Artist.ArtistID);

            toUpdate.ArtistName = Artist.ArtistName;
            // etc. for additional properties

            projectDbContext.SaveChanges();
        }

        public IQueryable<Artist> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
