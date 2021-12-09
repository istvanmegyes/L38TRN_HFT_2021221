using L38TRN_HFT_2021221.Models;
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
        IAlbumRepository albumRepo;
        ISongRepository songRepo;

        public ArtistLogic(IArtistRepository artistRepo, IAlbumRepository albumRepo, ISongRepository songRepo)
        {
            this.artistRepo = artistRepo;
            this.albumRepo = albumRepo;
            this.songRepo = songRepo;
        }

        public void Update(Artist artist)
        {
            if (artist != null)
            {
                artistRepo.Update(artist);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public Artist Read(int id)
        {
            if (artistRepo.GetOne(id) != null)
            {
                return artistRepo.GetOne(id);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public IEnumerable<Artist> ReadAll()
        {
            return artistRepo.GetAll().ToList();
        }

        public void Create(Artist artist)
        {
            if (artist != null)
            {
                artistRepo.Create(artist);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public void Delete(int id)
        {
            if (artistRepo.GetOne(id) != null)
            {
                artistRepo.DeleteArtist(id);
            }
            else
            {
                throw new InvalidOperationException("ERROR");
            }
        }

        public IEnumerable<KeyValuePair<string, int>> GetNationalityCountOfArtists()
        {
            return from x in artistRepo.GetAll()
                   group x by (x.Nationality) into g
                    select new KeyValuePair<string, int>(
                        g.Key,
                        g.Count()
                    );

        }

        public IEnumerable<KeyValuePair<string, double>> ArtistsMostExpensiveAlbum()
        {
            return from x in artistRepo.GetAll()
                    join y in albumRepo.GetAll()
                    on x.ID equals y.ArtistID
                    let z = new { ArtistName = x.ArtistName, SoldAlbums = y.Price }
                    group z by (x.ArtistName) into g
                    select new KeyValuePair<string, double>
                    (
                        g.Key,
                        g.Max(x => x.SoldAlbums)
                    );
        }

        public IEnumerable<KeyValuePair<string, int>> ArtistsHighestSellingAlbum()
        {
            var q = from x in artistRepo.GetAll()
                    join y in albumRepo.GetAll()
                    on x.ID equals y.ArtistID
                    let z = new {ArtistName = x.ArtistName, SoldAlbums = y.SoldAlbums}
                    group z by (x.ArtistName) into g
                    select new
                    {
                        _ArtistName = g.Key,
                        _SoldAlbums = g.Max(x=>x.SoldAlbums)
                    };

            var output = new List<KeyValuePair<string, int>>();

            foreach (var item in q)
            {
                output.Add(new KeyValuePair<string, int>(item._ArtistName, item._SoldAlbums));
            }

            return output;
        }

        public IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsByArtist()
        {
            var q = from x in artistRepo.GetAll()
                    join y in albumRepo.GetAll()
                    on x.ID equals y.ArtistID
                    let z = new { ArtistName = x.ArtistName, AlbumCount = y.SoldAlbums }
                    group z by (x.ArtistName) into g
                    select new
                    {
                        _ArtistName = g.Key,
                        _AlbumCount = g.Count()
                    };

            var output = new List<KeyValuePair<string, int>>();

            foreach (var item in q)
            {
                output.Add(new KeyValuePair<string, int>(item._ArtistName, item._AlbumCount));
            }

            return output;
        }

        public IEnumerable<KeyValuePair<string, double>> AverageSongDurationByArtists()
        {
            var q = from x in artistRepo.GetAll()
                    join y in albumRepo.GetAll()
                    on x.ID equals y.ArtistID
                    join w in songRepo.GetAll()
                    on y.ID equals w.AlbumID
                    let z = new { ArtistName = x.ArtistName, SongDuration = w.Duration }
                    group z by (z.ArtistName) into g
                    select new
                    {
                        _ArtistName = g.Key,
                        _AVGSongDuration = g.Average(v=>v.SongDuration)
                    };

            var output = new List<KeyValuePair<string, double>>();

            foreach (var item in q)
            {
                output.Add(new KeyValuePair<string, double>(item._ArtistName, item._AVGSongDuration));
            }

            return output;
        }

        public IEnumerable<KeyValuePair<string, int>> NumberOfSongByArtist()
        {
            var q = from x in artistRepo.GetAll()
                    join y in albumRepo.GetAll()
                    on x.ID equals y.ArtistID
                    join w in songRepo.GetAll()
                    on y.ID equals w.AlbumID
                    let z = new { ArtistName = x.ArtistName, NumberOfListenings = w.NumberOfListens }
                    group z by (z.ArtistName) into g
                    select new
                    {
                        _ArtistName = g.Key,
                        _NumberOfListenings = g.Count()
                    };

            var output = new List<KeyValuePair<string, int>>();

            foreach (var item in q)
            {
                output.Add(new KeyValuePair<string, int>(item._ArtistName, item._NumberOfListenings));
            }

            return output;
        }
    }
}
