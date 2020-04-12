using System;

namespace PlayingCard
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Card card = new Card(2, 4);
                int cardRank = card.getRank();
                int cardSuit = card.getSuit();
                string theCorrespondingRank = Card.rankToString(cardRank);
                string theCorrespondingSuit = Card.suitToString(cardSuit);

                Console.WriteLine($"The rank number of the card is {cardRank}.");
                Console.WriteLine($"The suit number of the card is {cardSuit}.");
                Console.WriteLine($"The corresponding string to the rank of the card is {theCorrespondingRank}.");
                Console.WriteLine($"The corresponding string to the suit of the card is {theCorrespondingSuit}.");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
