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
            // Artists
            Artist kendrickLamar = new Artist() { ID = 1, ArtistName = "Kendrik Lamar", Nationality = "US", NumberOfAwards = 160, Age = 34 };
            Artist postMalone = new Artist() { ID = 2, ArtistName = "Post Malone", Nationality = "US", NumberOfAwards = 30, Age = 26};
            Artist eminem = new Artist() { ID = 3, ArtistName = "Eminem", Nationality = "US", NumberOfAwards = 148, Age = 49};
            Artist theWeeknd = new Artist() { ID = 4, ArtistName = "The Weeknd", Nationality = "US", NumberOfAwards = 138, Age = 31};
            Artist daftPunk = new Artist() { ID = 5, ArtistName = "Daft Punk", Nationality = "FR", NumberOfAwards = 13};

            // Albums
            Album goodKid = new Album() { ID = 1, ArtistID = kendrickLamar.ID, Title = "Good Kid, M.A.A.D City", Price = 13.99, Genre = "Hip Hop", SoldAlbums = 240000};
            Album randomAccessMemories = new Album() { ID = 2, ArtistID = daftPunk.ID, Title = "Random Access Memories", Price = 5.99, Genre = "Disco", SoldAlbums = 195000};
            Album stoney = new Album() { ID = 3, ArtistID = postMalone.ID, Title = "Stoney", Price = 9.99, Genre = "Hip Hop", SoldAlbums = 128000};
            Album starboy = new Album() { ID = 4, ArtistID = theWeeknd.ID, Title = "Starboy", Price = 8.59, Genre = "Alternative R&B", SoldAlbums = 209000};
            Album encore = new Album() { ID = 5, ArtistID = eminem.ID, Title = "Encore", Price = 16.00, Genre = "Hip Hop", SoldAlbums = 710000};

            // Songs
            Song backseatFreestlye = new Song() { ID = 1, SongName = "Backseat Freestyle", AlbumID = goodKid.ID, Duration = 3.32, NumberOfListens = 289176395 };
            Song poeticJustice = new Song() { ID = 2, SongName = "Poetic Justice", AlbumID = goodKid.ID, Duration = 5.00, NumberOfListens =  322798018};
            Song moneyTrees = new Song() { ID = 3, SongName = "Money Trees", AlbumID = goodKid.ID, Duration = 6.26, NumberOfListens = 576237597 };
            Song swimmingPools = new Song() { ID = 4, SongName = "Swimming Pools (Drank)",  AlbumID = goodKid.ID, Duration = 5.13, NumberOfListens = 278295684 };
            Song compton = new Song() { ID = 5, SongName = "Compton",  AlbumID = goodKid.ID, Duration = 7.23, NumberOfListens = 57399251 };

            Song getLucky = new Song() { ID = 6, SongName = "Get Lucky", AlbumID = randomAccessMemories.ID, Duration = 6.09, NumberOfListens = 317510797};
            Song giorgioByMoroder = new Song() { ID = 7, SongName = "Giorgio by Moroder", AlbumID = randomAccessMemories.ID, Duration = 9.04, NumberOfListens = 88177657};
            Song beyond = new Song() { ID = 8, SongName = "Beyond", AlbumID = randomAccessMemories.ID, Duration = 4.50, NumberOfListens = 42911085};

            Song patient = new Song() { ID = 9, SongName = "Patient", AlbumID = stoney.ID, Duration = 3.14, NumberOfListens = 200606640};
            Song tooYoung = new Song() { ID = 10, SongName = "Too Young", AlbumID = stoney.ID, Duration = 3.57, NumberOfListens = 279644790 };
            Song congratulations = new Song() { ID = 11, SongName = "Congratulations", AlbumID = stoney.ID, Duration = 3.40, NumberOfListens = 1487866579 };

            Song falseAlarm = new Song() { ID = 12, SongName = "False Alarm", AlbumID = starboy.ID, Duration = 3.50, NumberOfListens = 208150925};
            Song reminder = new Song() { ID = 13, SongName = "Reminder", AlbumID = starboy.ID, Duration = 3.38, NumberOfListens = 371916854};
            Song partyMonster = new Song() { ID = 14, SongName = "Party Monster", AlbumID = starboy.ID, Duration = 4.09, NumberOfListens = 416888389};

            Song assLikeThat = new Song() { ID = 15, SongName = "Ass Like That", AlbumID = encore.ID, Duration = 4.25, NumberOfListens = 127074688};
            Song justLoseIt = new Song() { ID = 16, SongName = "Just Lose It", AlbumID = encore.ID, Duration = 4.08, NumberOfListens = 167008080};


            modelBuilder.Entity<Album>(entity => entity.HasOne(album => album.Artist).WithMany(artist => artist.Albums).HasForeignKey(x => x.ArtistID).OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Song>(entity => entity.HasOne(song => song.Album).WithMany(album => album.Songs).HasForeignKey(x => x.AlbumID).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Artist>().HasData(kendrickLamar,postMalone,eminem,theWeeknd,daftPunk);
            modelBuilder.Entity<Album>().HasData(goodKid,randomAccessMemories,stoney,starboy,encore);
            modelBuilder.Entity<Song>().HasData(
                backseatFreestlye, poeticJustice, moneyTrees, swimmingPools, compton,
                getLucky,giorgioByMoroder,beyond,
                patient,tooYoung,congratulations,
                falseAlarm,reminder,partyMonster,
                assLikeThat,justLoseIt); 
        }
    }
}
