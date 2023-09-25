using System.Collections;

class Player {
    public string Name {get; private set; }
    public Player(string name)
    {
        this.Name = name;
    }
    public byte PointsInGame = 0;
    public bool TurnBriscola = false;
    public List<Card> Cards = new();
    readonly Stack<Card> Mazzo = new();
    public void PushMazzo(Card card) => Mazzo.Push(card);
    public byte GetMazzoPoints() {
        byte ret = 0;
        foreach(var c in Mazzo){
            ret += c.Value;
        }
        return ret;
    }
}