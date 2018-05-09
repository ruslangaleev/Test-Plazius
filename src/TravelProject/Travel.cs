using System.Collections.Generic;
using System.Linq;
using System;

namespace TravelProject
{
    public class Travel
    {
        /// <summary>
        /// Сортировка карточек для путешествия
        /// </summary>
        public TravelCard[] Sort(TravelCard[] cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException(nameof(cards));
            }

            if (cards.Length == 0)
            {
                return cards;
            }

            var newCards = new List<TravelCard>();

            // 1.1 Ищем точку отправления, на которую не ссылает другая карточка
            foreach (var entry in cards)
            {
                var card = cards.FirstOrDefault(t => entry.From == t.To);
                // Нашли точку отправления, на которую не ссылается другая карточка
                if (card == null)
                {
                    var any = cards.FirstOrDefault(t => entry.To == t.From);
                    if (any == null)
                    {
                        throw new Exception($"Карточка '{entry.From} - {entry.To}' не имеет существующую точку отправки и точку назначения");
                    }

                    newCards.Add(entry);
                }
            }

            // 1.2 Если в карточках замкнутый путь, то берем самый первый
            if (newCards.Count == 0)
            {
                newCards.Add(cards.FirstOrDefault());
            }

            // 2. Ищем пути и добавляем в список
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
