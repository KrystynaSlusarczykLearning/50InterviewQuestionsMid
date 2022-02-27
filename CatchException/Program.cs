public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var numbers = Enumerable.Empty<int>();
            var first = GetFirstOrDefault(numbers);

            //let's make the application crash on purpose:
            throw new Exception("Unknown exception");
        }
        //global catch block is one of the few places
        //where catch(Exception) is appropriate
        catch (Exception ex)
        {
            //writing to some application logs would be appropriate here
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An unexpected error happened and " +
                $"the application can't continue. The error message is" +
                $" '{ex.Message}', stack trace is : {ex.StackTrace}");
        }
        Console.ReadKey();
    }

    private static T? GetFirstOrDefault<T>(IEnumerable<T> items)
    {
        try
        {
            return items.First();
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("The collection is empty!");
            return default(T);
        }
    }

    private static double Average(IEnumerable<int> numbers)
    {
        if(numbers == null)
        {
            throw new ArgumentNullException(
                "The numbers collection is null!");
        }
        double sum = 0;
        int count = 0;
        foreach (var number in numbers)
        {
            sum += number;
            count++;
        }
        if(count > 0)
        {
            return sum / count;
        }
        throw new InvalidOperationException(
            "The collection is empty!");
    }

    public class GuiLayer
    {
        private BusinessLayer _businessLayer;
        private ILogger _logger;

        public GuiLayer(
            BusinessLayer businessLayer,
            ILogger logger)
        {
            _businessLayer = businessLayer;
            _logger = logger;
        }

        public void ShowToUser()
        {
            try
            {
                var data = _businessLayer.GetProcessedData();
                Console.WriteLine($"Showing to user: {data}");
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in GUI Layer: " + ex);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error: '{ex.Message}'");
            }
        }
    }

    public class BusinessLayer
    {
        private ILogger _logger;
        private DataAccessLayer _dataAccessLayer;

        public BusinessLayer(
            DataAccessLayer dataAccessLayer,
            ILogger logger)
        {
            _dataAccessLayer = dataAccessLayer;
            _logger = logger;
        }

        public string GetProcessedData()
        {
            try
            {
                var rawData = _dataAccessLayer.GetRawData();
                return rawData.Trim();
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in BusinessLayer: " + ex);
                throw; //rethrowing the exception
            }
        }
    }

    public class DataAccessLayer
    {
        private readonly ILogger _logger;

        public DataAccessLayer(ILogger logger)
        {
            _logger = logger;
        }

        public string GetRawData()
        {
            try
            {
                return " some raw data ";
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in DataAccessLayer: " + ex);
                throw; //rethrowing the exception
            }
        }
    }

    public interface ILogger
    {
        void LogError(string message);
    }
}

