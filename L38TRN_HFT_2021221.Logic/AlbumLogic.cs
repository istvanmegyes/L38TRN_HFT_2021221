using L38TRN_HFT_2021221.Models;
using L38TRN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L38TRN_HFT_2021221.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        IAlbumRepository albumRepo;

        public void Update(int id, string newName)
        {
            albumRepo.UpdateAlbumName(id, newName);
        }

        public Album Read(int id)
        {
            return albumRepo.GetOne(id);
        }

        public List<Album> GetAll()
        {
            return albumRepo.GetAll().ToList();
        }

        public void Create(Album album)
        {
            albumRepo.Create(album);
        }

        public void Delete(int id)
        {
            albumRepo.DeleteAlbum(id);
        }

        public IEnumerable<Album> ReadAll()
        {
           return albumRepo.GetAll();
        }
    }
}
