using L38TRN_HFT_2021221.Models;
using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Test
{
    class TestWithFake
    {
        private class FakeArtistRepository : IArtistRepository
        {
            public void Create(Artist artist)
            {

            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public void DeleteArtist(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Artist> GetAll()
            {
                throw new NotImplementedException();
            }

            public Artist GetOne(int id)
            {
                throw new NotImplementedException();
            }

            public Artist Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Artist> ReadAll()
            {
                ICollection<Song> fakeSong = new ICollection<Song>();
                return new List<Artist>()
                {
                    new Artist()
                    {
                        ArtistName = "Lil Pump",
                        Nationality = "hungarian",
                        Songs = fakeSong
                    },
                    new Artist()
                    {
                        ArtistName = "Deljisa Gjon",
                        Nationality = "english",
                        Songs = fakeSong
                    }
                }.AsQueryable();
            }

            public void Update(Artist artist)
            {
                throw new NotImplementedException();
            }

            public void UpdateArtistName(int id, string newName)
            {
                throw new NotImplementedException();
            }

            public void UpdateArtistNationality(int id, string newNationality)
            {
                throw new NotImplementedException();
            }
        }

        ArtistLogic al;

        public TestWithFake()
        {
            al = new ArtistLogic(new FakeArtistRepository());
        }

        [Test]
        public void AVGPriceTest()
        {
            //ACT
            var result = al.AVGPrice();

            //ASSERT
            Assert.That(result, Is.EqualTo(1500));
        }

        [Test]
        public void AVGPriceByBrandsTest()
        {
            //ACT
            var result = al.AVGPriceByBrands().ToArray();

            //ASSERT
            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, double>
                ("Peugeot", 1500)));
        }

        [TestCase(-3000, false)]
        [TestCase(3000, true)]
        public void CreateArtistTest(string artistName, bool result, string artistName, ICollection<Song> songs)
        {

            //ACT + ASSERT
            if (result)
            {
                Assert.That(() => al.Create(new Artist()
                {
                    ArtistName = "Korda György",
                    
                    Nationality = "hungarian"
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => al.Create(new Artist()
                {
                    ArtistName = "Korda György",

                    Nationality = "hungarian"
                }), Throws.Exception);
            }

        }
    }
}
