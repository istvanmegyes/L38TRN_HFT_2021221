using L38TRN_HFT_2021221.Data;
using System;
using System.Collections.Generic;

namespace L38TRN_HFT_2021221.Logic
{
    public class AlbumLogic
    {
        public void ChangeAlbumName(int id, string newName)
        {
            albumRepo.ChangeAlbumName(id, newName);
        }

        public Album GetOneArtist(int id)
        {
            return albumRepo.GetOne(id);
        }

        public List<Album> GetAll()
        {
            return albumRepo.GetAll().ToList();
        }

        public void InsertAlbum(Album album)
        {
            albumRepo.CreateAlbum(album);
        }

        public void DeleteAlbumById(int id)
        {
            albumRepo.DeleteAlbumById(id);
        }
    }
}
