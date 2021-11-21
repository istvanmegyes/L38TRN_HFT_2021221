using L38TRN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public class SongRepository : Repository<Song>
    {
        public SongRepository(ProjectDbContext projectDbContext) : base(projectDbContext) { }

        public override Song GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.SongId == id);
        }

        public void UpdateSongName(int id, string newSongName)
        {
            var Song = GetOne(id);
            Song.SongName = newSongName;
            projectDbContext.SaveChanges();
        }

        public void AddNewSong(Song Song)
        {
            projectDbContext.Add(Song);
            projectDbContext.SaveChanges();
        }

        public void DeleteSongById(int id)
        {
            var toDelete = GetOne(id);
            projectDbContext.Remove(toDelete);
            projectDbContext.SaveChanges();
        }

        public void UpdateSong(Song Song)
        {
            var toUpdate = GetOne(Song.SongId);

            toUpdate.Content = Song.Content;
            // etc. for additional properties

            projectDbContext.SaveChanges();
        }
    }
}
