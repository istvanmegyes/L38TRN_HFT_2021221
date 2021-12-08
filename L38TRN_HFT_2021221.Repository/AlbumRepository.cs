using L38TRN_HFT_2021221.Data;
using L38TRN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(ProjectDbContext projectDbContext) : base(projectDbContext) { }
        public override Album GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ID == id);
        }

        public void Create(Album album)
        {
            projectDbContext.Add(album);
            projectDbContext.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            var toDelete = GetOne(id);
            projectDbContext.Remove(toDelete);
            projectDbContext.SaveChanges();
        }

        public void UpdateAlbumName(int id, string newAlbumName)
        {
            var toUpdate = GetOne(id);
            toUpdate.Title = newAlbumName;
            projectDbContext.SaveChanges();
        }

        public void UpdateAlbumPrice(int id, int newPrice)
        {
            var toUpdate = GetOne(id);
            toUpdate.Price = newPrice;
            projectDbContext.SaveChanges();
        }

    }
}
