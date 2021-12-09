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

        public AlbumLogic(IAlbumRepository albumRepo)
        {
            this.albumRepo = albumRepo;
        }

        public void Update(Album album)
        {
            if (album != null)
            {
                albumRepo.Update(album);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public Album Read(int id)
        {
            if (albumRepo.GetOne(id) != null)
            {
                return albumRepo.GetOne(id);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            } 
        }

        public List<Album> GetAll()
        {
            return albumRepo.GetAll().ToList();
        }

        public void Create(Album album)
        {
            if (album != null)
            {
                albumRepo.Create(album);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public void Delete(int id)
        {
            if (albumRepo.GetOne(id) != null)
            {
                albumRepo.DeleteAlbum(id);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public IEnumerable<Album> ReadAll()
        {
           return albumRepo.GetAll();
        }

        public IEnumerable<Album> CheapAlbums()
        {
            return from x in albumRepo.GetAll()
                   where x.Price < 10
                   select x;
        }

        public IEnumerable<Album> ExpensiveAlbums()
        {
            return from x in albumRepo.GetAll()
                   where x.Price > 25
                   select x;
        }
    }
}
