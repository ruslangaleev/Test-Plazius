using NUnit.Framework;
using System;
using TravelProject;

namespace TravelProjectTest
{
    [TestFixture]
    public class TravelTests
    {
        [Test(Description = "Вернет список упорядоченных карточек")]
        public void ReturnsValidSortedLit()
        {
            // INIT
            var sourceCards = new TravelCard[]
            {
                new TravelCard
                {
                    From = "Мельбурн",
                    To = "Кельн"
                },
                new TravelCard
                {
                    From = "Кельн",
                    To = "Москва"
                },
                new TravelCard
                {
                    From = "Москва",
                    To = "Париж"
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
                    From = "Кельн",
                    To = "Москва"
                },
                new TravelCard
                {
                    From = "Москва",
                    To = "Париж"
                }
            };

            var travel = new Travel();

            // ACT
            var actualCards = travel.Sort(sourceCards);

            // ASSERT
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
            // INIT
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

            var travel = new Travel();

            // ACT / ASSERT
            Assert.Throws<Exception>(() => travel.Sort(sourceCards));
        }
    }
}
