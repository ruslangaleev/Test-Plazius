using System.Collections.Generic;
using System.Linq;

namespace TravelCard
{
    public interface IExample
    {
        TravelCard[] Sort(TravelCard[] cards);
    }

    public class Example : IExample
    {
        public TravelCard[] Sort(TravelCard[] cards)
        {
            var newCards = new List<TravelCard>();

            // Ищем точку отправления, на которую не ссылает другая карточка
            foreach (var entry in cards)
            {
                var card = cards.FirstOrDefault(t => entry.From == t.To);
                // Нашли точку отправления, на которую не ссылается другая карточка
                if (card == null)
                {
                    var any = cards.FirstOrDefault(t => entry.To == t.From);
                    if (any == null)
                    {
                        throw new System.Exception($"Карточка '{entry.From} - {entry.To}' не имеет существующую точку отправки и точку назначения");
                    }

                    newCards.Add(entry);
                    //break;
                }
            }

            if (newCards.Count == 0)
            {
                newCards.Add(cards.FirstOrDefault());
            }

            for(int i = 0; i < cards.Length; i++)
            {
                var lastCard = newCards.LastOrDefault();

                var card = cards.FirstOrDefault(t => lastCard.To == t.From);
                if (card != null)
                {
                    newCards.Add(card);
                }
            }

            return newCards.ToArray();
        }
    }
}
