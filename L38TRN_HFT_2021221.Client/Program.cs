using System;
using ConsoleTools;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L38TRN_HFT_2021221.Models;

namespace L38TRN_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService restService = new RestService();
            Init(ref restService);


            ConsoleMenu mainMenu = new ConsoleMenu();
            ConsoleMenu crudMenu = new ConsoleMenu();
            ConsoleMenu nonCrudMenu = new ConsoleMenu();

            mainMenu
                .Add("CRUD Menu", () => crudMenu.Show())
                .Add("Non-CRUD Menu", () => nonCrudMenu.Show())
                .Add("Exit Program", () => Environment.Exit(0));

            crudMenu
                .Add("Albums",() => AlbumQueries(restService))
                .Add("Artists", () => ArtistQueries(restService))
                .Add("Songs", () => SongQueries(restService))
                .Add("Go Back", () => mainMenu.Show())
                .Add("Exit Program", () => Environment.Exit(0));

            nonCrudMenu
                .Add("Nationality Statistics",() => GetQuery<KeyValuePair<string, int>>(restService, "GetNationalityCountOfArtists"))
                .Add("The most expensive album of the artists", () => GetQuery<KeyValuePair<string, double>>(restService, "ArtistsMostExpensiveAlbum"))
                .Add("The highest selling album of the artists", () => GetQuery<KeyValuePair<string, int>>(restService, "ArtistsHighestSellingAlbum"))
                .Add("Number of albums by artist", () => GetQuery<KeyValuePair<string, int>>(restService, "NumberOfAlbumsByArtist"))
                .Add("The average song duration by artist", () => GetQuery<KeyValuePair<string, double>>(restService, "AverageSongDurationByArtists"))
                .Add("Number of songs by artist", () => GetQuery<KeyValuePair<string, int>>(restService, "NumberOfSongByArtist"))
                .Add("Go Back", () => mainMenu.Show())
                .Add("Exit Program", () => Environment.Exit(0));

            mainMenu.Show();
        }

        static void Init(ref RestService restService)
        {
            try
            {
                restService = new RestService("http://localhost:3445");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void GetQuery<T>(RestService restService, string query) 
        {
            var results = restService.Get<T>($"noncrud/{query.ToLower()}");
            foreach (var item in results)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        static void AlbumQueries(RestService restService) 
        {
            Album test = new Album {ArtistID = 1, Title = "TestAlbum", Genre = "Hip Hop", SoldAlbums = 2424 };
            restService.Post<Album>(test,"album");
            Console.WriteLine("\nNew Album has been created.");

            int testAlbumID = restService.Get<Album>("album").Count() - 1;
            Album tempAlbum = restService.Get<Album>(testAlbumID, "album");

            restService.Put<Album>(new Album() { 
                ArtistID = tempAlbum.ArtistID, 
                Genre ="Rap", 
                SoldAlbums = tempAlbum.SoldAlbums,
                Price = tempAlbum.Price,
                Title = tempAlbum.Title
            }, "album");

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"\nThe album with the id ({tempAlbum.ID}) has been updated.");
            Console.WriteLine($"The updated album: \n" + tempAlbum.ToString());

            Console.WriteLine($"\nThe album with the id ({tempAlbum.ID}) has been deleted.");
            System.Threading.Thread.Sleep(2000);
            restService.Delete(testAlbumID, "album");

            var album = restService.Get<Album>(1, "album");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(album.ToString());

            var allAlbums = restService.Get<Album>("album");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine();
            foreach (var item in allAlbums)
            {
                Console.WriteLine("\n" + item.ToString());
            }
            Console.ReadKey();
        }

        static void ArtistQueries(RestService restService)
        {
            Artist test = new Artist { ArtistName = "TestArtist", Nationality = "US", Age = 24, NumberOfAwards = 12 };
            restService.Post<Artist>(test, "artist");
            Console.WriteLine("\nNew Artist has been created.");

            int testArtistID = restService.Get<Artist>("Artist").Count() - 1;
            Artist tempArtist = restService.Get<Artist>(testArtistID, "artist");

            restService.Put<Artist>(new Artist()
            {
                Nationality = "FR",
                Age = tempArtist.Age,
                NumberOfAwards = tempArtist.NumberOfAwards,
                ArtistName = tempArtist.ArtistName
            }, "artist");

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"\nThe Artist with the id ({tempArtist.ID}) has been updated.");
            Console.WriteLine($"The updated Artist: \n" + tempArtist.ToString());

            Console.WriteLine($"\nThe Artist with the id ({tempArtist.ID}) has been deleted.");
            System.Threading.Thread.Sleep(2000);
            restService.Delete(testArtistID, "artist");

            var artist = restService.Get<Artist>(1, "artist");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(artist.ToString());

            var allArtists = restService.Get<Artist>("artist");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine();
            foreach (var item in allArtists)
            {
                Console.WriteLine("\n" + item.ToString());
            }
            Console.ReadKey();
        }

        static void SongQueries(RestService restService)
        {
            Song test = new Song { AlbumID = 1, SongName = "TestSong", Duration = 3.02, NumberOfListens = 241561612};
            restService.Post<Song>(test, "song");
            Console.WriteLine("New Song has been created.");

            int testSongID = restService.Get<Song>("song").Count() - 1;
            Song tempSong = restService.Get<Song>(testSongID, "song");

            restService.Put<Song>(new Song()
            {
                NumberOfListens = 243634464,
                SongName = tempSong.SongName,
                Duration = tempSong.Duration,
            }, "song");

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"\nThe Song with the id ({tempSong.ID}) has been updated.");
            Console.WriteLine($"The updated Song: \n" + testSongID.ToString());

            Console.WriteLine($"\nThe Song with the id ({tempSong.ID}) has been deleted.");
            System.Threading.Thread.Sleep(2000);
            restService.Delete(testSongID, "song");

            var song = restService.Get<Song>(1, "song");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(song.ToString());

            var allSongs = restService.Get<Song>("song");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine();
            foreach (var item in allSongs)
            {
                Console.WriteLine("\n"+item.ToString());
            }
            Console.ReadKey();
        }
    }
}
