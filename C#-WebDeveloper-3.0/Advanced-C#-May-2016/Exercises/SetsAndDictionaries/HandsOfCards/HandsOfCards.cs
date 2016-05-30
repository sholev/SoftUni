namespace BasicDictionaryOperations
{
    using System;
    using System.Collections.Generic;

    class HandsOfCards
    {
        static void Main(string[] args)
        {
            var playersCards = new Dictionary<string, HashSet<string>>();

            var input = Console.ReadLine().Trim();
            while (!input.ToLower().Contains("joker"))
            {
                var parameters = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var player = parameters[0];
                var playerHand = parameters[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (!playersCards.ContainsKey(player))
                {
                    playersCards[player] = new HashSet<string>();
                }

                foreach (var card in playerHand)
                {
                    playersCards[player].Add(card);
                }

                input = Console.ReadLine().Trim();
            }

            foreach (var playerCard in playersCards)
            {
                Console.WriteLine($"{playerCard.Key}: {CalculatePlayerPower(playerCard.Value)}");
            }
        }

        private static decimal CalculatePlayerPower(HashSet<string> hand)
        {
            var playerPower = 0M;
            var cardPowers = new Dictionary<char, decimal>
                                 {
                                     { '2', 2 }, { '1', 10 },
                                     { '3', 3 }, { 'j', 11 },
                                     { '4', 4 }, { 'q', 12 },
                                     { '5', 5 }, { 'k', 13 },
                                     { '6', 6 }, { 'a', 14 },
                                     { '7', 7 },
                                     { '8', 8 },
                                     { '9', 9 }
                                 };

            var cardMultipliers = new Dictionary<char, decimal>
                                      {
                                          { 's', 4 }, { 'h', 3 }, { 'd', 2 }, { 'c', 1 }
                                      };

            foreach (string card in hand)
            {
                var lowerCard = card.ToLower();
                var cardNumber = lowerCard[0];
                var cardType = lowerCard[lowerCard.Length - 1];

                playerPower += (cardPowers[cardNumber] * cardMultipliers[cardType]);
            }

            return playerPower;
        }
    }
}
