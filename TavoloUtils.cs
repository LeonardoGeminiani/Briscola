abstract class Mazziere {
    public static void GiveCards(Stack<Card> Mazzo, Player[] Players, byte n){ 
        for (byte i = 0; i < Players.Length; ++i){
            for(byte j = 0; j < n; j++) Players[i].Cards.Add(Mazzo.Pop());
        }
    }

    public static void GiveOneCard(Card[] Mazzo, Player[] Players){ 
        for (byte i = 0; i < Players.Length; ++i){
            Players[i].Cards.Add(Mazzo[i]);
        }
    }
}