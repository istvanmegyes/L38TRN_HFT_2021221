using L38TRN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Logic
{
    public class SongLogic
    {
        public void ChangeAlbumName(int id, string newName)
        {
            songRepo.ChangeAlbumName(id, newName);
        }

        public Song GetOneArtist(int id)
        {
            return songRepo.GetOne(id);
        }

        public List<Song> GetAll()
        {
            return songRepo.GetAll().ToList();
        }

        public void InsertSong(Song song)
        {
            songRepo.CreateSong(song);
        }

        public void DeleteSongById(int id)
        {
            songRepo.DeleteSongById(id);
        }
    }
}
