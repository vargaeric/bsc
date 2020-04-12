using System;

namespace PlayingCard
{
    internal class Card
    {
        int rank;
        int suit;

        // Kinds of ranks
        public static int ACE = 1;
        public static int DEUCE = 2;
        public static int THREE = 3;
        public static int FOUR = 4;
        public static int FIVE = 5;
        public static int SIX = 6;
        public static int SEVEN = 7;
        public static int EIGHT = 8;
        public static int NINE = 9;
        public static int TEN = 10;
        public static int JACK = 11;
        public static int QUEEN = 12;
        public static int KING = 13;

        // Kinds of suits
        public static int DIAMONDS = 1;
        public static int CLUBS = 2;
        public static int HEARTS = 3;
        public static int SPADES = 4;

        bool isValidRank(int rank)
            => ACE <= rank && rank <= KING;

        bool isValidSuit(int suit)
            => DIAMONDS <= suit && suit <= SPADES;

        public Card(int rank, int suit)
        {
            bool isValidRankBool = isValidRank(rank);
            bool isValidSuitBool = isValidSuit(suit);

            if (!isValidRankBool)
                throw new ArgumentException("Invalid rank number provided.");

            if (!isValidSuitBool)
                throw new ArgumentException("Invalid suit number provided.");

            this.rank = rank;
            this.suit = suit;
        }

        public int getRank() => rank;

        public int getSuit() => suit;

        public static String rankToString(int rank)
            => rank switch
                {
                    1 => "Ace",
                    2 => "Deuce",
                    3 => "Three",
                    4 => "Four",
                    5 => "Five",
                    6 => "Six",
                    7 => "Seven",
                    8 => "Eight",
                    9 => "Nine",
                    10 => "Ten",
                    11 => "Jack",
                    12 => "Queen",
                    13 => "King",
                    _ => null,
                };

        public static String suitToString(int suit)
            => suit switch
                {
                    1 => "Diamonds",
                    2 => "Clubs",
                    3 => "Hearts",
                    4 => "Spades",
                    _ => null,
                };
    }
}
