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

        public SongLogic(ISongRepository songRepo)
        {
            this.songRepo = songRepo;
        }

        public void Update(int id, Song song)
        {
            if (songRepo.GetOne(id) != null && song != null)
            {
                songRepo.Update(id, song);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public Song Read(int id)
        {
            if (songRepo.GetOne(id) != null)
            {
                return songRepo.GetOne(id);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public List<Song> GetAll()
        {
            return songRepo.GetAll().ToList();
        }

        public void Create(Song song)
        {
            if (song != null)
            {
                songRepo.Create(song);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }  
        }

        public void Delete(int id)
        {
            if (songRepo.GetOne(id) != null)
            {
                songRepo.DeleteSong(id);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public IEnumerable<Song> ReadAll()
        {
            return songRepo.GetAll();
        }

        public IEnumerable<Song> MostListenedSongs()
        {
            return from x in songRepo.GetAll()
                   where x.NumberOfListens > 150000
                   select x;
        }

        public IEnumerable<Song> LeastListenedSongs()
        {
            return from x in songRepo.GetAll()
                   where x.NumberOfListens < 1000
                   select x;
        }
    }
}
