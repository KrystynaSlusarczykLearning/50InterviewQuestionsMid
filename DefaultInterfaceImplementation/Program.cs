CustomOrder orderConcreteType = new CustomOrder();
//we can't use the default implementation on the concrete type
//orderConcreteType.DelayDeliveryByDays(1);

//but we can use it via the interface
IOrder order = new CustomOrder();
order.DelayDeliveryByDays(1);

IOrder orderWithDelay = new CustomOrderWithDelay();
orderWithDelay.DelayDeliveryByDays(1);
orderWithDelay.VirtualMethodFromInterface();
Console.ReadKey();


class CustomOrder : IOrder
{
    public IEnumerable<IItem> Items { get; } = new List<IItem>();

    public ICustomer Customer {get;}

    public void Place()
    {
        Console.WriteLine("Placing an order");
    }
}

class CustomOrderWithDelay : IOrder
{
    public IEnumerable<IItem> Items { get; } = new List<IItem>();

    public ICustomer Customer { get; }

    public void Place()
    {
        Console.WriteLine("Placing an order");
    }

    public void DelayDeliveryByDays(int days)
    {
        Console.WriteLine("DelayDeliveryByDays from CustomOrderWithDelay");

        //we can't use the protected method from the base interface
        //in the class implementing the interface
        //var x = ProtectedMethod();
    }

    //we can't override the virtual method from interface in the class
    //public override void VirtualMethodFromInterface() { }
}

public interface IOrder
{
    public virtual void VirtualMethodFromInterface()
    {
        Console.WriteLine("IOrder interface");
    }

    IEnumerable<IItem> Items { get; }
    ICustomer Customer { get; }
    void Place();
    void DelayDeliveryByDays(int days)
    {
        Console.WriteLine($"DelayDeliveryByDays from interface");
    }

    protected int ProtectedMethod() => 0;
}

public interface ICancellableOrder : IOrder
{
    void IOrder.VirtualMethodFromInterface()
    {
        Console.WriteLine("ICancellableOrder interface");

        //we can use the protected method from the base interface here
        var x = ProtectedMethod();
    }
    void Cancel();
}

public interface IItem
{
    string Name { get; }
    decimal Price { get; }
}

public interface ICustomer
{
    string Name { get; }
    string Email { get; }
}