var bitcoinPriceReader = new BitcoinPriceReader();

var emailPriceChangeNotifier = new EmailPriceChangeNotifier(25000);
bitcoinPriceReader.AttachObserver(emailPriceChangeNotifier);

var pushPriceChangeNotifier = new PushPriceChangeNotifier(40000);
bitcoinPriceReader.AttachObserver(pushPriceChangeNotifier);

bitcoinPriceReader.ReadCurrentPrice();
bitcoinPriceReader.ReadCurrentPrice();

Console.WriteLine("Push notifications OFF");
bitcoinPriceReader.DetachObserver(pushPriceChangeNotifier);

bitcoinPriceReader.ReadCurrentPrice();

Console.ReadKey();

public interface IObserver<TData>
{
    void Update(TData data);
}

public interface IObservable<TData>
{
    void AttachObserver(IObserver<TData> observer);
    void DetachObserver(IObserver<TData> observer);
    void NotifyObservers();
}

public class BitcoinPriceReader : IObservable<decimal>
{
    private decimal _currentBitcoinPrice;
    private List<IObserver<decimal>> _observers = 
        new List<IObserver<decimal>>();

    public void AttachObserver(IObserver<decimal> observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver<decimal> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_currentBitcoinPrice);
        }
    }

    public void ReadCurrentPrice()
    {
        _currentBitcoinPrice = new Random().Next(0, 50000);

        NotifyObservers();
    }
}

public class EmailPriceChangeNotifier : IObserver<decimal>
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal currentBitcoinPrice)
    {
        if (currentBitcoinPrice > _notificationThreshold)
        {
            Console.WriteLine($"Sending an email saying that " +
                $"the Bitcoin price exceeded {_notificationThreshold} " +
                $"and is now {currentBitcoinPrice}\n");
        }
    }
}

public class PushPriceChangeNotifier : IObserver<decimal>
{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal currentBitcoinPrice)
    {
        if (currentBitcoinPrice > _notificationThreshold)
        {
            Console.WriteLine($"Sending a push notification saying that " +
                $"the Bitcoin price exceeded {_notificationThreshold} " +
                $"and is now {currentBitcoinPrice}\n");
        }
    }
}