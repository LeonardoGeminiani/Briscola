enum CardFamilies {
    Spade,
    Coppe,
    Denari,
    Bastoni
}

class Card {
    // img
    // value --done
    // family --done
    // value in game --done
    private readonly byte value;
    public readonly CardFamilies family;
    private static readonly ArgumentException exValue = new("Invalid value for a Card, must be a number between 1 and 10");
    public Card(byte value, CardFamilies family)
    {
        if(value == 0 || value > 10) throw exValue;
        this.value = value;
        this.family = family;
    }

    public byte ValueInGame {
        get => this.value switch
        {
            1 => 9,
            3 => 8,
            10 => 7,
            2 => 0,
            _ => (byte)(this.value - 3),
        };
    }

    public byte Value {
        get => this.value switch
        {
            1 => 11,
            3 => 10,
            10 => 4,
            9 => 3,
            8 => 2,
            _ => 0,
        };
    }

    public static string GetCardFamily(byte value){
        return value switch
        {
            1 => "Asso",
            8 => "Donna",
            9 => "Cavallo",
            10 => "Re",
            _ => value.ToString(),
        };
    }
    override public string ToString() {
        return Card.GetCardFamily(this.value) + " di " + this.family.ToString();
    }
}