using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCard
{
    [TestFixture]
    public class TravelCardTests
    {
        [Test(Description = "Вернет список упорядоченных карточек")]
        public void ReturnsValidSortedLit()
        {
            var sourceCards = new TravelCard[]
            {
                new TravelCard
                {
                    From = "Мельбурн",
                    To = "Кельн"
                },
                new TravelCard
                {
                    From = "Москва",
                    To = "Париж"
                },
                new TravelCard
                {
                    From = "Кельн",
                    To = "Москва"
                }
            };

            var expectedCards = new TravelCard[]
            {
                new TravelCard
                {
                    From = "Мельбурн",
                    To = "Кельн"
                },
                new TravelCard
                {
                    From = "Москва",
                    To = "Париж"
                },
                new TravelCard
                {
                    From = "Кельн",
                    To = "Москва"
                }
            };

            var example = new Example();
            var actualCards = example.Sort(sourceCards);

            Assert.Multiple(() =>
            {
                for(int i = 0; i < expectedCards.Length; i++)
                {
                    Assert.AreEqual(expectedCards[i].From, actualCards[i].From);
                    Assert.AreEqual(expectedCards[i].To, actualCards[i].To);
                }
            });
        }
        
        [Test(Description = "Вернет исключение, т.к. одна из карточек содержит в себе несуществующий пункт отправления или пункт назначения")]
        public void ThrowsException_If_CardInvalid()
        {
            var sourceCards = new TravelCard[]
{
                new TravelCard
                {
                    From = "Мельбурн",
                    To = "Кельн"
                },
                new TravelCard
                {
                    From = "Москва",
                    To = "Париж"
                },
                new TravelCard
                {
                    From = "Кельн",
                    To = "Москва"
                },
                new TravelCard
                {
                    From = "Казань",
                    To = "Париж"
                }
            };

            var example = new Example();

            Assert.Throws<Exception>(() => example.Sort(sourceCards));
        }
    }
}
