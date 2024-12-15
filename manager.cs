using ConcertCreator;
using TicketManager;

namespace ConcertManager;

class Manager {
    public List<Ticket> TicketList;
    public List<Concert> ConcertList;

    public Manager() {
        TicketList = new();
        ConcertList = new();
    }

    public void Choose() {
        Console.Write("What action do you want to execute? (Add new concert - A, Book a concert - B, Search for concert - C, Exit program - D): ");
        string? choice = Console.ReadLine();

        switch(choice) {
            case "A":
                AddConcert();
                break;
            case "B":
                BookConcert();
                break;
            case "C":
                SearchForConcert();
                break;
            case "D":
                System.Environment.Exit(0);
                break;
            default:
                Choose();
                break;
        }
    }

    public void AddConcert() {
        Console.Write("Enter concert name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter date of concert: ");
        string? date = Console.ReadLine();

        Console.Write("Enter concert location: ");
        string? location = Console.ReadLine();

        Console.Write("Enter number of seats: ");
        string? seats = Console.ReadLine();
        
        Console.Write("Enter type of concert: ");
        string? type = Console.ReadLine();
        
        Console.Write("Enter price of the ticket: ");
        string? price = Console.ReadLine();
        
        if(int.TryParse(seats, out int realSeats)) {
            if(int.TryParse(price, out int realPrice)) {
                ConcertList.Add(new Concert(name, date, location, realSeats, type, realPrice));
            } else {
                Console.WriteLine("Price is incorrect!");
            }
        } else {
            Console.WriteLine("Number of seats is incorrect!");
        }
    }
    public void BookConcert() {
        Console.Write("Concert Name: ");
        string? name = Console.ReadLine();
        Console.Write("Ticket Owner Name: ");
        string? owner = Console.ReadLine();

        List<Concert> Filter = ConcertList.Where(con => con.Name == name).ToList();

        if (Filter.Count < 1) {
            Console.WriteLine($"Concert \"{name}\" doesn't exist!");
        } else {
            int index = ConcertList.FindIndex(x => x.Name == name);
            TicketList.Add(new Ticket(name, ConcertList[index].AvalibleSeats, owner));
            ConcertList[index].AvalibleSeats--;
        }
    }
    public void SearchForConcert() {
        List<Concert> filterList = ConcertList;

        Console.Write("Search for concert by name, leave blank to choose all: ");
        string? name = Console.ReadLine();
        Console.Write("Search for concert by date, leave blank to choose all: ");
        string? date = Console.ReadLine();
        Console.Write("Search for concert by location, leave blank to choose all: ");
        string? location = Console.ReadLine();

        if(name != "") {
            filterList = filterList.Where(concert => concert.Name == name).ToList();
        }
        if(date != "") {
            filterList = filterList.Where(concert => concert.Date == date).ToList();
        }
        if(location != "") {
            filterList = filterList.Where(concert => concert.Location == location).ToList();
        }

        Console.WriteLine($"{filterList.Count} concert(s) found.");
        foreach(Concert concert in filterList) {
            Console.WriteLine($"{concert.Name} ({concert.Type}) on {concert.Date} in {concert.Location}. {concert.AvalibleSeats} seats left. Ticket costs ${concert.Price}");
        }
    }
}