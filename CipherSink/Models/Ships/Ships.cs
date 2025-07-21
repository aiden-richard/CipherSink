namespace CipherSink.Models.Ships;

internal class Carrier : Ship
{
    public Carrier() : base("Carrier", 5, OccupationType.Carrier) { }
}

internal class Battleship : Ship
{
    public Battleship() : base("Battleship", 4, OccupationType.Battleship) { }
}

internal class Cruiser : Ship
{
    public Cruiser() : base("Cruiser", 3, OccupationType.Cruiser) { }
}

internal class Submarine : Ship
{
    public Submarine() : base("Submarine", 3, OccupationType.Submarine) { }
}

internal class Destroyer : Ship
{
    public Destroyer() : base("Destroyer", 2, OccupationType.Destroyer) { }
}