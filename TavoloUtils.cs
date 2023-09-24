abstract class Mazziere {
    public static void GiveCards(Stack<Card> Mazzo, Player[] Players){ 
        for (int i = 0; i < Players.Length; ++i){
            Card[] c = {Mazzo.Pop(), Mazzo.Pop(), Mazzo.Pop()};
            Players[i].Cards = new(c);
        }
    }
}