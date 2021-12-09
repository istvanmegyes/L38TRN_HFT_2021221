using L38TRN_HFT_2021221.Data;
using L38TRN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(ProjectDbContext projectDbContext) : base(projectDbContext) { }

        public override Song GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ID == id);
        }

        public void UpdateSongName(int id, string newSongName)
        {
            var Song = GetOne(id);
            Song.SongName = newSongName;
            projectDbContext.SaveChanges();
        }

        public void Create(Song Song)
        {
            projectDbContext.Add(Song);
            projectDbContext.SaveChanges();
        }

        public void DeleteSong(int id)
        {
            var toDelete = GetOne(id);
            projectDbContext.Remove(toDelete);
            projectDbContext.SaveChanges();
        }

        public void UpdateSongDuration(int id, int newDuration)
        {
            var toUpdate = GetOne(id);
            toUpdate.Duration = newDuration;

            projectDbContext.SaveChanges();
        }

        public void Update(Song song)
        {
            var temp = GetOne(song.ID);
            temp = song;
            projectDbContext.SaveChanges();
        }
    }
}
