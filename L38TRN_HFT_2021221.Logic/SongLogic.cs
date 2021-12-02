using L38TRN_HFT_2021221.Models;
using L38TRN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Logic
{
    public class SongLogic : ISongLogic
    {
        ISongRepository songRepo;
        public void Update(int id, string newSongName)
        {
            songRepo.UpdateSongName(id, newSongName);
        }

        public Song Read(int id)
        {
            return songRepo.GetOne(id);
        }

        public List<Song> GetAll()
        {
            return songRepo.GetAll().ToList();
        }

        public void Create(Song song)
        {
            songRepo.Create(song);
        }

        public void Delete(int id)
        {
            songRepo.DeleteSong(id);
        }

        public IEnumerable<Song> ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
