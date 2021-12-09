using L38TRN_HFT_2021221.Models;
using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace L38TRN_HFT_2021221.Test
{
    [TestFixture]
    public class ProjectTests
    {
        ArtistLogic artistLogic;
        AlbumLogic albumLogic;
        SongLogic songLogic;

        [SetUp]
        public void Init() 
        {
            var mockArtistRepository =
                new Mock<IArtistRepository>();

            var mockAlbumRepository =
                new Mock<IAlbumRepository>();

            var mockSongRepository =
                new Mock<ISongRepository>();

            var fakeArtists = new List<Artist> {
                                                new Artist { ID = 1, ArtistName = "TesztMax", Age=18, Nationality = "English", NumberOfAwards = 2,
                                                            Albums = new List<Album>() {
                                                                    new Album { ID = 1, ArtistID = 1, Genre = "RNB", Price = 35, SoldAlbums=250000, Title="RappAlbum", Songs =
                                                                            new List<Song> { new Song { ID = 1, SongName = "TesztSzam1", AlbumID =1, Duration = 2.45 },
                                                                                            new Song { ID = 2, SongName = "TesztSzam2", AlbumID =1, Duration = 7.2 },
                                                                                            new Song { ID = 3, SongName = "TesztSzam3", AlbumID =1, Duration = 2.2 } }  },
                                                                    new Album { ID = 2, ArtistID = 1, Genre = "Rock", Price = 35, SoldAlbums=100, Title="RockAlbum", Songs =
                                                                            new List<Song> { new Song { ID = 4, SongName = "TesztSzam1", AlbumID =1, Duration = 2.45 } } }
                                                            }
                                                },
                                                new Artist { ID = 2, ArtistName = "TesztJani", Age=30, Nationality = "English", NumberOfAwards = 20,
                                                        Albums = new List<Album>() {
                                                                    new Album { ID = 3, ArtistID = 2, Genre = "Metál", Price = 5, SoldAlbums=5678, Title="MetálAlbum", Songs =
                                                                            new List<Song> {new Song { ID = 5, SongName = "Szam2", AlbumID = 3, Duration = 2.12 },
                                                                                            new Song { ID = 6, SongName = "Szam3", AlbumID = 3, Duration = 5 } } 
                                                                            }
                                                        }
                                                },
                                                new Artist { ID = 3, ArtistName = "Géza", Age=69, Nationality = "English", NumberOfAwards = 12,
                                                        Albums = new List<Album>() {
                                                                new Album { ID = 4, ArtistID = 3, Genre = "Pop", Price = 10, SoldAlbums=5678, Title="MulatósAlbum", Songs =
                                                                            new List<Song> {new Song { ID = 7, SongName = "Szam42", AlbumID = 4, Duration = 2.43 },
                                                                                            new Song { ID = 8, SongName = "Szam23", AlbumID = 4, Duration = 5.56 } }  },
                                                                new Album { ID = 5, ArtistID = 3, Genre = "Pop", Price = 21, SoldAlbums=24151516, Title="PopAlbum", Songs =
                                                                            new List<Song> {new Song { ID = 9, SongName = "SzamDF2", AlbumID = 5, Duration = 3.12 } } },
                                                                new Album { ID = 6, ArtistID = 3, Genre = "Metál", Price = 44, SoldAlbums=42069, Title="KekszAlbum", Songs =
                                                                            new List<Song> {new Song { ID = 10, SongName = "SzamSok2", AlbumID = 6, Duration = 2.45 } }  }
                                                        }

                                                }
            }.AsQueryable();

            Artist a1 = new Artist() { ID = 4, ArtistName = "JoTesztEloado1", Age = 22 };
            Artist a2 = new Artist() { ID = 5, ArtistName = "JoTesztEloado2", Age = 22 };

            var fakeAlbums = new List<Album> { new Album() { ID = 7, ArtistID = 1, Artist = a1, SoldAlbums = 21010303, Genre="Pop",  Title = "TesztAlbum1", Price = 45.00 },
                                               new Album() { ID = 8, ArtistID = 1, Artist = a1, SoldAlbums = 231, Genre="Rock", Title = "TesztAlbum2", Price = 1.99 },
                                               new Album() { ID = 9, ArtistID = 2, Artist = a2, SoldAlbums = 536, Genre="Jazz", Title = "TesztAlbum3", Price = 18.00 }
        }.AsQueryable();
            var fakeSongs = new List<Song> { new Song { ID = 5, SongName = "Compton", AlbumID =7, Duration = 2.75, NumberOfListens = 2000000 },
                                            new Song { ID = 6, SongName = "Fazék", AlbumID =7, Duration = 3.5, NumberOfListens = 20 },
                                            new Song { ID = 7, SongName = "Kés és héjas alma", AlbumID =8, Duration = 2.5, NumberOfListens = 10 },
                                            new Song { ID = 8, SongName = "Teszt", AlbumID =8, Duration = 5, NumberOfListens = 100 },
                                            new Song { ID = 9, SongName = "Damu roland", AlbumID =8, Duration = 2.5, NumberOfListens = 400 },
                                            new Song { ID = 10, SongName = "Valami", AlbumID =9, Duration = 2.5, NumberOfListens = 2 }}.AsQueryable();

            mockArtistRepository.Setup((t) => t.GetAll()).Returns(fakeArtists);
            mockAlbumRepository.Setup((t) => t.GetAll()).Returns(fakeAlbums);
            mockSongRepository.Setup((t) => t.GetAll()).Returns(fakeSongs);

            artistLogic = new ArtistLogic(mockArtistRepository.Object, mockAlbumRepository.Object, mockSongRepository.Object);
            albumLogic = new AlbumLogic(mockAlbumRepository.Object);
            songLogic = new SongLogic(mockSongRepository.Object);
        }

        [TestCase]
        public void CreateArtistTest()
        {
            Artist artist = new Artist
            {
                ID = 1,
                ArtistName = "Steve",
                Nationality = "Hungarian",
                Age = 21,
                NumberOfAwards = 12
            };

            try
            {
                artistLogic.Create(artist);
                Assert.Pass();
            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase]
        public void CreateSongTest()
        {
            Song song = new Song
            {
                ID = 1,
                SongName = "Steve",
                Duration = 4.52,
                NumberOfListens = 21
            };

            try
            {
                songLogic.Create(song);
                Assert.Pass();
            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase]
        public void CreateAlbumTest()
        {
            Album album = new Album
            {
                ID = 1,
                Title = "MenőAlbum",
                Genre = "Hip-hop",
                Price = 53.2
            };

            try
            {
                albumLogic.Create(album);
                Assert.Pass();
            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase]
        public void Update()
        {
            Artist artist = new Artist
            {
                ID = 1,
                ArtistName = "TesztFerenc",
                Age = 18,
                Albums = new List<Album>() {
                    new Album { ID = 1, ArtistID = 1, Genre = "RNB", Price = 35, SoldAlbums=250000, Title="RappAlbum", Songs =
                            new List<Song> { new Song { ID = 1, SongName = "TesztSzam1", AlbumID =1, Duration = 2.45 },
                                            new Song { ID = 2, SongName = "TesztSzam2", AlbumID =1, Duration = 7.2 },
                                            new Song { ID = 3, SongName = "TesztSzam3", AlbumID =1, Duration = 2.2 } }  },
                    new Album { ID = 2, ArtistID = 1, Genre = "Rock", Price = 35, SoldAlbums=100, Title="RockAlbum", Songs =
                            new List<Song> { new Song { ID = 4, SongName = "TesztSzam1", AlbumID =1, Duration = 2.45 } } }
                }
            };

            try
            {
                artistLogic.Update(artist);
                Assert.Pass();
            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase]
        public void GetNationalityCountOfArtistsTest() 
        {
            var result = artistLogic.GetNationalityCountOfArtists().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("English", 3)));
        }

        [TestCase]
        public void ArtistsMostExpensiveAlbumTest() 
        {
            var result = artistLogic.ArtistsMostExpensiveAlbum().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("TesztMax", 45)));
        }

        [TestCase]
        public void ArtistsHighestSellingAlbumTest() 
        {
            var result = artistLogic.ArtistsHighestSellingAlbum().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("TesztMax", 21010303)));
        }

        [TestCase]
        public void NumberOfAlbumsByArtistTest()
        {
            var result = artistLogic.NumberOfAlbumsByArtist().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("TesztMax",2)));
        }

        [TestCase]
        public void AverageSongDurationByArtistsTest()
        {
            var result = artistLogic.AverageSongDurationByArtists().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, double>("TesztMax", 3.25)));
        }

        [TestCase]
        public void NumberOfSongByArtistTest()
        {
            var result = artistLogic.NumberOfSongByArtist().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("TesztMax", 5)));
        }

    }
}
