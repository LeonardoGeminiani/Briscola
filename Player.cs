class Player {

    public string Name {get; private set; }
    public Player(string name)
    {
        this.Name = name;
    }

    public List<Card>? Cards;
}