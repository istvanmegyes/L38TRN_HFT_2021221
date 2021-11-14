using L38TRN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public class AlbumRepository : Repository<Album>
    {
        public override Album GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void AddNewAlbum(Album Album)
        {
            projectDbContext.Add(Album);
            projectDbContext.SaveChanges();
        }

        public void ChangeTitle(int id, string newTitle)
        {
            var Album = GetOne(id);
            Album.Title = newTitle;
            projectDbContext.SaveChanges();
        }

        public void DeleteAlbumById(int id)
        {
            var toDelete = GetOne(id);
            projectDbContext.Remove(toDelete);
            projectDbContext.SaveChanges();
        }

        public override Album GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.AlbumId == id);
        }

        public void UpdateAlbum(Album Album)
        {


            projectDbContext.SaveChanges();
        }
    }
}
