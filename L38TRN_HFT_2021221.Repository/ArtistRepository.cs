using L38TRN_HFT_2021221.Data;
using L38TRN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ProjectDbContext projectDbContext) : base(projectDbContext) { }

        public override Artist GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ID == id);
        }

        public void UpdateArtistName(int id, string newName)
        {
            var Artist = GetOne(id);
            Artist.ArtistName = newName;

            projectDbContext.SaveChanges();
        }

        public void Create(Artist artist)
        {
            projectDbContext.Add(artist);
            projectDbContext.SaveChanges();
        }

        public void DeleteArtist(int id)
        {
            var toDelete = GetOne(id);
            projectDbContext.Remove(toDelete);
            projectDbContext.SaveChanges();
        }

        public void UpdateArtistNationality(int id, string newNationality)
        {
            var toUpdate = GetOne(id);

            toUpdate.ArtistName = newNationality;

            projectDbContext.SaveChanges();
        }

        public void Update(Artist artist)
        {
            var temp = GetOne(artist.ID);
            //temp = artist;
            foreach (var prop in temp.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t=>t.IsVirtual) == null)
                {
                    prop.SetValue(temp, prop.GetValue(artist));
                }
            }
            projectDbContext.SaveChanges();
        }
    }
}
