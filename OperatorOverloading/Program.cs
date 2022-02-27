var point1 = new Point(10, 5);
var point2 = new Point(-3, 4);
var result = point1 + point2;
//Console.WriteLine(point1.Add(point2));
Console.WriteLine(point1 + point2);

//implicit conversion
int a = 5;
double b = a;

//implicit conversion won't work here because we will lose precision
double c = 5.5d;
//int d = c;

//we must use explicit conversion
int d = (int)c;

Point fromTuple = (Point)(5, 7);

Console.ReadKey();

static void ReceiveExternalPoint((float, float) externalPoint)
{
    //Point point = new Point(externalPoint.Item1, externalPoint.Item2);
    Point point = externalPoint;
    Console.WriteLine($"{point} received");

    //this doesn't work, I can't use implicit cast from double to int
    //int a = 10.1;
    int a = (int)10;
    double b = 10;
}

static void ReceiveExternalPointDouble((double, double) externalPoint)
{
    Point point = (Point)externalPoint;
    Console.WriteLine($"{point} received");
}

record struct Point
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Point Add(Point other)
    {
        return new Point(X + other.X, Y + other.Y);
    }

    public static Point operator +(Point point1, Point point2) =>
        new Point(point1.X + point1.X, point1.Y + point2.Y);

    public static implicit operator Point((float, float) externalPoint) =>
        new Point(externalPoint.Item1, externalPoint.Item2);

    public static explicit operator Point((double, double) externalPoint) =>
        new Point((float)externalPoint.Item1, (float)externalPoint.Item2);
}