
Console.ReadKey();

public record Subscriber(string Email, bool IsPremium);

public class Subscribers
{
    //public Subscriber[] Items;
    public IEnumerable<Subscriber> Items => _items; //we expose an abstract collection
    private HashSet<Subscriber> _items { get; }
    public Subscribers(HashSet<Subscriber> items) => _items = items;
}

public class NewsletterSender
{
    private Subscribers _subscribers;

    public NewsletterSender(Subscribers subscribers)
    {
        _subscribers = subscribers;
    }

    public void SendTo(bool premiumSubscribersOnly)
    {
        foreach (var subscriber in _subscribers.Items.Where(s =>
             !premiumSubscribersOnly || s.IsPremium))
        {
            Console.WriteLine($"Newsletter sent to {subscriber.Email}");
        }
    }

    //this worked for array only
    //public void SendTo(bool premiumSubscribersOnly)
    //{
    //    for (int i = 0; i < _subscribers.Items.Length; i++)
    //    {
    //        if (!premiumSubscribersOnly ||
    //            _subscribers.Items[i].IsPremium)
    //        {
    //            Console.WriteLine(
    //                $"Newsletter sent to " +
    //                $"{_subscribers.Items[i].Email}");
    //        }
    //    }
    //}
}
