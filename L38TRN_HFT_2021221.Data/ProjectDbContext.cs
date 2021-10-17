using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Album>(entity => entity.HasOne(artist => artist.ArtistName).WithMany(artist => artist.Albums).OnDelete(DeleteBehavior.SetNull));
            modelBuilder.Entity<Song>(entity => entity.HasOne(song => song.AlbumName).WithMany(album => album.Songs).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<Song>(entity => entity.HasOne(song => song.AlbumName).WithMany(artist => artist.Songs).OnDelete(DeleteBehavior.ClientSetNull));

            Artist kendrickLamar = new Artist() { ArtistID = 1, ArtistName = "Kendrik Lamar" };
            Album goodKid = new Album() { AlbumID = 1, AlbumName = "Good Kid, M.A.A.D City", ArtistName = kendrickLamar };
            Song backseatFreestlye = new Song() { SongID = 1, AlbumName = goodKid, ArtistName = kendrickLamar, Duration = 212};

            modelBuilder.Entity<Album>().HasData(kendrickLamar);
            modelBuilder.Entity<Artist>().HasData(goodKid);
            modelBuilder.Entity<Song>().HasData(backseatFreestlye);

        }
    }
}
