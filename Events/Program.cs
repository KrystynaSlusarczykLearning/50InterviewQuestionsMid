var bitcoinPriceReader = new BitcoinPriceReader();

//events and delegate-type fields seems similar...
//bitcoinPriceReader.PriceRead += SomeMethod;
//bitcoinPriceReader.PriceReadNotAnEvent += SomeMethod;

//...but we can't invoke an event from outside of the class it belongs to
//bitcoinPriceReader.PriceRead(100);

var emailPriceChangeNotifier = new EmailPriceChangeNotifier(25000);
var pushPriceChangeNotifier = new PushPriceChangeNotifier(40000);

bitcoinPriceReader.PriceRead += emailPriceChangeNotifier.Update;
bitcoinPriceReader.PriceRead += pushPriceChangeNotifier.Update;

bitcoinPriceReader.ReadCurrentPrice();
bitcoinPriceReader.ReadCurrentPrice();

//it's a good practice to unsubscribe from event handler
bitcoinPriceReader.PriceRead -= emailPriceChangeNotifier.Update;
bitcoinPriceReader.PriceRead -= pushPriceChangeNotifier.Update;

Console.ReadKey();

void SomeMethod(decimal price)
{
    Console.WriteLine($"Price is {price}");
}

public class BitcoinPriceReader 
{
    private int _currentBitcoinPrice;

    //we can use custom delegate for events
    //public event PriceRead? PriceRead;
    //public PriceRead? PriceReadNonEvent;

    //or the built-in EventHandler delegate 
    public event EventHandler<PriceReadEventArgs> PriceRead;

    public void ReadCurrentPrice()
    {
        _currentBitcoinPrice = new Random().Next(0, 50000);
        OnPriceRead(_currentBitcoinPrice);
    }

    private void OnPriceRead(decimal price)
    {
        PriceRead?.Invoke(this, new PriceReadEventArgs(price));
    }
}

public delegate void PriceRead(decimal price);

public class EmailPriceChangeNotifier 
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(object sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            Console.WriteLine($"Sending an email saying that " +
                $"the Bitcoin price exceeded {_notificationThreshold} " +
                $"and is now {eventArgs.Price}\n");
        }
    }
}

public class PushPriceChangeNotifier 
{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(object sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            Console.WriteLine($"Sending a push notification saying that " +
                $"the Bitcoin price exceeded {_notificationThreshold} " +
                $"and is now {eventArgs.Price}\n");
        }
    }
}

public delegate void PriceReadEventHandler(
    object sender, PriceReadEventArgs e);

public class PriceReadEventArgs : EventArgs
{
    public decimal Price { get; }

    public PriceReadEventArgs(decimal price)
    {
        Price = price;
    }
}