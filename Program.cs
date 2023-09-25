const byte N_PLAYERS = 2;

var rnd = new Random();
var Mazzo = new Stack<Card>();

{ // Mazzo creation
    var Mazzo_tmp = new Card[40];
    for (byte i = 0, j = 1, k = 0; i < Mazzo_tmp.Length; i++, j++) { // populate mazzo
        var family = (CardFamilies)k;
        if(!(N_PLAYERS == 3 && j == 2 && family == CardFamilies.Coppe))
            Mazzo_tmp[i] = new(j, family);
        if(j == 10) {
            j = 0;
            ++k;
        }
    }
    rnd.Shuffle<Card>(Mazzo_tmp); // shuffle the mazzo 
    foreach (var m in Mazzo_tmp) Mazzo.Push(m);
}

Player[] Players = new Player[N_PLAYERS];
for (int i = 0; i < Players.Length; i++) Players[i] = new Player($"c{i}");

//  lascia la briscola sul tavolo
Card Briscola;
Card tmp = Briscola = Mazzo.Pop();
Stack<(Card card, Player? player)> Table = new();
Table.Push((tmp, null));

byte NCards = 3;
bool exit = false;
while(!exit){
    // maziere distribuische carte a tutti
    if(Mazzo.Count == N_PLAYERS-1){
        // ultima mano
        Mazzo.Push(Briscola);
        Mazziere.GiveOneCard(Mazzo.ToArray(), Players);
        exit = true;
    }
    else Mazziere.GiveCards(Mazzo, Players, NCards);
    NCards = 1;

    foreach(var j in Players) {
        Console.WriteLine();
        PrintTable(Table);
        Console.WriteLine();
        Table.Push((SelectDropCard(j), j));
    }

    byte[] points = new byte[N_PLAYERS];
    
    Stack<(Player Player, Card Card)>? WithBriscola = null;
    foreach(var card in Table){
        if(card.player is null) continue;
        card.player.TurnBriscola = card.card.family == Briscola.family;
        if(card.player.TurnBriscola){
            WithBriscola ??= new();
            WithBriscola.Push((card.player, card.card));
        }
        card.player.PointsInGame += card.card.ValueInGame;
    }

    Player? max = null;
    if(WithBriscola is null){
        foreach(var p in Players) {
            if(max is null || p.PointsInGame > max.PointsInGame) max = p;
        }
    }else {
        foreach(var p in WithBriscola){
            if(max is null || p.Card.ValueInGame > max.PointsInGame) max = p.Player;
        }
    }

    Console.WriteLine($"Player {max!.Name}, ha preso le carte");
    for(int i = 0; i < (exit ? Table.Count : N_PLAYERS); ++i){
        max!.PushMazzo(Table.Pop().card);
    }
}

Player winner = Players[0];
for(byte i = 0; i < N_PLAYERS; ++i){
    if(winner.GetMazzoPoints() < Players[i].GetMazzoPoints()){
        winner = Players[i];
    }
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"il giocatore:{winner.Name} ha vinto!");
Console.ResetColor();

static Card SelectDropCard(Player player){
    Console.WriteLine($"Giocatore {player.Name}, seleziona la carta:");
    byte n = 0;
    player.Cards.ForEach(card => {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(n);
        Console.ResetColor();
        Console.Write($": {card}\n");
        ++n;
    });
    byte i = Convert.ToByte(Console.ReadLine());
    Card ret = player.Cards.ElementAt(i);
    player.Cards.RemoveAt(i);
    return ret;
}

static void PrintTable(Stack<(Card, Player?)> Table) {
    foreach (var i in Table) {
        if(i.Item2 == null) Console.Write("Briscola: ");
        Console.Write(i.Item1 + "\n");
    }
}