﻿using L38TRN_HFT_2021221.Data;
using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        IArtistRepository artistRepo;
        public ArtistLogic()
        {
            artistRepo = new ArtistRepository(new ProjectDbContext());
        }

        public ArtistLogic(IArtistRepository repo)
        {
            this.artistRepo = repo;
        }

        public void ChangeArtistName(int id, string newName)
        {
            artistRepo.UpdateArtistName(id, newName);
        }

        public Artist GetOneArtist(int id)
        {
            return artistRepo.GetOne(id);
        }

        public List<Artist> GetAll()
        {
            return artistRepo.GetAll().ToList();
        }

        public void CreateNewArtist(Artist artist)
        {
            artistRepo.Create(artist);
        }

        public void DeleteArtistById(int id)
        {
            artistRepo.DeleteArtist(id);
        }

        public void Create(Artist artist)
        {
            throw new NotImplementedException();
        }

        public Artist Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, Album>> AVGAlbumsByArtist()
        {
            throw new NotImplementedException();
        }
    }
}
