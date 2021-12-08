using Microsoft.EntityFrameworkCore;
using L38TRN_HFT_2021221.Models;
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
            Artist kendrickLamar = new Artist() { ID = 1, ArtistName = "Kendrik Lamar" };

            Album goodKid = new Album() { ID = 1, ArtistID = kendrickLamar.ID, Title = "Good Kid, M.A.A.D City", Price = 13.99 };

            Song backseatFreestlye = new Song() { ID = 1, SongName = "Backseat Freestyle", AlbumID = goodKid.ID, Duration = 212 };
            Song poeticJustice = new Song() { ID = 2, SongName = "Poetic Justice", Album = goodKid, AlbumID = goodKid.ID, Duration = 212 };
            Song moneyTrees = new Song() { ID = 3, SongName = "Money Trees", Album = goodKid, AlbumID = goodKid.ID, Duration = 212 };
            Song swimmingPools = new Song() { ID = 4, SongName = "Swimming Pools (Drank)", Album = goodKid, AlbumID = goodKid.ID, Duration = 212 };
            Song compton = new Song() { ID = 5, SongName = "Compton", Album = goodKid, AlbumID = goodKid.ID, Duration = 212 };


            modelBuilder.Entity<Album>(entity => entity.HasOne(album => album.Artist).WithMany(artist => artist.Albums).HasForeignKey(x => x.ArtistID).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<Song>(entity => entity.HasOne(song => song.Album).WithMany(album => album.Songs).HasForeignKey(x => x.AlbumID).OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Artist>().HasData(kendrickLamar);
            modelBuilder.Entity<Album>().HasData(goodKid);
            modelBuilder.Entity<Song>().HasData(backseatFreestlye);//, poeticJustice, moneyTrees, swimmingPools, compton); 
        }
    }
}
