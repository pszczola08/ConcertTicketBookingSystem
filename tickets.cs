namespace TicketManager;

class Ticket {
    public string Owner;
    public string Concert;
    public int SeatNumber;

    public Ticket(string concert, int seatNumber, string owner) {
        Concert = concert;
        SeatNumber = seatNumber;
        Owner = owner;
    }
}