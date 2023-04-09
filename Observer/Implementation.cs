namespace Observer
{
    public class TicketChange
    {
        public int Amount { get; private set; }
        public int ArtistId { get; private set; }

        public TicketChange(int amount, int artistId)
        {
            Amount = amount;
            ArtistId = artistId;
        }
    }

    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _observers = new();

        public void AddObserver(ITicketChangeListener listener) 
        {
            _observers.Add(listener);
        }

        public void RemoveObserver(ITicketChangeListener listener) 
        {
            _observers.Remove(listener);
        }

        public void NotifyObservers(TicketChange ticketChange) 
        {
            foreach (ITicketChangeListener listener in _observers) 
            {
                listener.ReceiveTicketChangeNoticication(ticketChange);
            }
        }
    }

    public interface ITicketChangeListener
    {
        void ReceiveTicketChangeNoticication(TicketChange ticketChange);
    }

    public class OrderService : TicketChangeNotifier
    {
        public void CompleteTicketSale(int artistId, int amount)
        {
            Console.WriteLine($"{nameof(OrderService)} is changing its state.");
            Console.WriteLine($"{nameof(OrderService)} is notifying observers.");
            NotifyObservers(new TicketChange(amount, artistId));
        }
    }

    public class TicketResellerService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNoticication(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketResellerService)} notified of ticket change: artist {ticketChange.ArtistId}, amount {ticketChange.Amount}");
        }
    }

    public class TicketStockService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNoticication(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketStockService)} notified of ticket change: artist {ticketChange.ArtistId}, amount {ticketChange.Amount}");
        }
    }

}
