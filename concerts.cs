namespace ConcertCreator;

class Concert {
    public string Name;
    public string Date;
    public string Location;
    public int AvalibleSeats;
    public string Type;
    public int Price;

    public Concert(string Name, string Date, string Location, int AvalibleSeats, string Type, int Price) {
        this.Name = Name;
        this.Date = Date;
        this.Location = Location;
        this.AvalibleSeats = AvalibleSeats;
        this.Type = Type;
        this.Price = Price;
    }

    public string GetConcertInfo() {
        return $"{Name}, starting {Date} in {Location}. There are {AvalibleSeats} seats left.";
    }

    public void Reduce(int Seats) {
        AvalibleSeats -= Seats;
    }
}