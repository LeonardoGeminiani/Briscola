const byte N_PLAYERS = 2;

var rnd = new Random();
var Mazzo = new Stack<Card>();

{ // Mazzo creation
    var Mazzo_tmp = new Card[40];
    for (byte i = 0, j = 1, k = 0; i < Mazzo_tmp.Length; i++, j++) { // populate mazzo
        Mazzo_tmp[i] = new(j, (CardFamilies)k);
        if(j == 10) {
            j = 0;
            ++k;
        }
    }
    rnd.Shuffle<Card>(Mazzo_tmp); // shuffle the mazzo 
    foreach (var m in Mazzo_tmp) Mazzo.Push(m);
}

var Players = new Player[N_PLAYERS];
for (int i = 0; i < Players.Length; i++) Players[i] = new Player("c");

// maziere distribuische 3 carte a tutti
Mazziere.GiveCards(Mazzo, Players);

//  lascia la briscola sul tavolo
Card Briscola;
Card tmp = Briscola = Mazzo.Pop();
Stack<Card> Table = new Stack<Card>();
Table.Push(tmp);

while (true) {
    PrintTable(Table, Briscola);
}

void PrintTable(Stack<Card> Table, Card Briscola) {
    foreach (var i in Table) {
        if(i == Briscola) Console.Write("Briscola: ");
        Console.Write(i + "\n");
    }
}