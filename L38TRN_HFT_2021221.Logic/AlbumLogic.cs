using L38TRN_HFT_2021221.Data;
using L38TRN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L38TRN_HFT_2021221.Logic
{
    public class AlbumLogic
    {
        IAlbumRepository albumRepo;

        public void ChangeAlbumName(int id, string newName)
        {
            albumRepo.UpdateAlbumName(id, newName);
        }

        public Album GetOneArtist(int id)
        {
            return albumRepo.GetOne(id);
        }

        public List<Album> GetAll()
        {
            return albumRepo.GetAll().ToList();
        }

        public void CreateNewAlbum(Album album)
        {
            albumRepo.Create(album);
        }

        public void DeleteAlbumById(int id)
        {
            albumRepo.DeleteAlbum(id);
        }
    }
}
