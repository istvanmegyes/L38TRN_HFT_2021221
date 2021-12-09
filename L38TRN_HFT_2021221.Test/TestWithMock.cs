using L38TRN_HFT_2021221.Data;
using L38TRN_HFT_2021221.Logic;
using L38TRN_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Test
{
    class TestWithMock
    {
        /*
        ArtistLogic al;
        public TestWithMock()
        {
            Mock<IArtistRepository> mockArtistRepository =
                new Mock<IArtistRepository>();

            Song fakeSong = new Song()
            {
                SongName = "TrekkMánia"
            };

            mockArtistRepository.Setup((t) => t.Create(It.IsAny<Artist>()));
            mockArtistRepository.Setup((t) => t.ReadAll()).Returns(
                new List<Artist>()
                {
                    new Artist()
                    {
                        ArtistName = "Csóré duó",
                    Nationality = "hungarian"

                    },
                    new Artist()
                    {
                        ArtistName = "Csóré duó",
                    Nationality = "hungarian"
                    }
                }.AsQueryable());

            al = new ArtistLogic(mockArtistRepository.Object);
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
                ("Csóré duó", 1500)));
        }

        [TestCase(-3000, false)]
        [TestCase(3000, true)]
        public void CreateCarTest(int price, bool result)
        {

            //ACT + ASSERT
            if (result)
            {
                Assert.That(() => al.Create(new Artist()
                {
                    ArtistName = "Csóré duó",
                    Nationality = "hungarian"
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => al.Create(new Artist()
                {
                    ArtistName = "Edda",
                    Nationality = "hungarian"
                }), Throws.Exception);
            }

        }*/
    }
}
