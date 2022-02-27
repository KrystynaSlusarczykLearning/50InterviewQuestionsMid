int twoBillion = 2000000000;
var result = twoBillion + twoBillion;

Console.WriteLine("two billion + two billion is " + result);

//the below code will thrown an exception,
//because on overflow will happen in the checked scope
//byte maxValueForByte = byte.MaxValue;
//checked
//{
//    //this will throw an exception
//    maxValueForByte++;
//}

var account1 = new Account();
account1.MakePaymentNotChecked(1900000000);
account1.MakePaymentNotChecked(1000000000);

var account2 = new Account();
account2.MakePaymentChecked(1900000000);
account2.MakePaymentChecked(1000000000);

int Add(int a, int b)
{
    return a + b;
}

void SomeMethodWithCheckedScopeInside()
{
    try
    {
        checked
        {
            int i = Add(twoBillion, twoBillion);
        }
    }
    catch(OverflowException)
    {
        Console.WriteLine("Exception!");
    }
    Console.WriteLine("SomeMethodWithCheckedScopeInside is finished");
}

SomeMethodWithCheckedScopeInside();
Console.ReadKey();

public class Account
{
    private int _todaysPaymentsSum;
    private const int MaxDailyPaymentsSum = 2000000000;

    public void MakePaymentChecked(int amount)
    {
        checked
        {
            try
            {
                var paymentsSumAfterPayment = _todaysPaymentsSum + amount;
                if (paymentsSumAfterPayment < MaxDailyPaymentsSum)
                {
                    _todaysPaymentsSum = paymentsSumAfterPayment;
                    Console.WriteLine($"[CHECKED] {amount} transferred! " +
                        $"(Payments sum for today: {_todaysPaymentsSum})");
                }
                else
                {
                    Console.WriteLine($"Transaction limit of " +
                        $"{MaxDailyPaymentsSum} reached!");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Overflow exception happened!");
            }
        }
    }

    public void MakePaymentNotChecked(int amount)
    {
        var paymentsSumAfterPayment = _todaysPaymentsSum + amount;
        if (paymentsSumAfterPayment < MaxDailyPaymentsSum)
        {
            _todaysPaymentsSum = paymentsSumAfterPayment;
            Console.WriteLine($"[UNCHECKED] {amount} transferred! " +
                $"(Payments sum for today: {_todaysPaymentsSum})");
        }
        else
        {
            Console.WriteLine($"Transaction limit of " +
                $"{MaxDailyPaymentsSum} reached!");
        }
    }
}
