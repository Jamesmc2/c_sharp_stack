namespace DeckOfCards.models
{
    public class Card
    {
        public string Suit {get;}
        public string Value {get;}
        public int NumValue{get;}
        public Card(string suit, string value, int numvalue){
            Suit = suit;
            Value = value;
            NumValue = numvalue;
        }
        public string Display() 
        {
            return $"The {Value} of {Suit}";
        }
    }
}