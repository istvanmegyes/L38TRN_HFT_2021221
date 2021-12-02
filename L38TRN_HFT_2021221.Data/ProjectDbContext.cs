﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Data
{
    public class ProjectDbContext : DbContext
    {
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        public ProjectDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjectDatabase.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            Artist kendrickLamar = new Artist() { ArtistID = 1, ArtistName = "Kendrik Lamar" };

            Album goodKid = new Album() { AlbumID = 1, AlbumName = "Good Kid, M.A.A.D City", Price = 13.99 };

            Song backseatFreestlye = new Song() { SongID = 1, SongName = "Backseat Freestyle", AlbumName = goodKid, Duration = 212 };
            Song poeticJustice = new Song() { SongID = 2, SongName = "Poetic Justice", AlbumName = goodKid, ArtistName = kendrickLamar, Duration = 212 };
            Song moneyTrees = new Song() { SongID = 3, SongName = "Money Trees", AlbumName = goodKid, ArtistName = kendrickLamar, Duration = 212 };
            Song swimmingPools = new Song() { SongID = 4, SongName = "Swimming Pools (Drank)", AlbumName = goodKid, ArtistName = kendrickLamar, Duration = 212 };
            Song compton = new Song() { SongID = 5, SongName = "Compton", AlbumName = goodKid, ArtistName = kendrickLamar, Duration = 212 };

            goodKid.Artist = kendrickLamar;

            modelBuilder.Entity<Album>(entity => entity.HasOne(album => album.Artist).WithMany(artist => artist.Albums).OnDelete(DeleteBehavior.SetNull));
            modelBuilder.Entity<Song>(entity => entity.HasOne(song => song.AlbumName).WithMany(album => album.Songs).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<Song>(entity => entity.HasOne(song => song.AlbumName).WithMany(artist => artist.Songs).OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Album>().HasData(kendrickLamar);
            modelBuilder.Entity<Artist>().HasData(goodKid);
            modelBuilder.Entity<Song>().HasData(backseatFreestlye, poeticJustice, moneyTrees, swimmingPools, compton); 
        }
    }
}
