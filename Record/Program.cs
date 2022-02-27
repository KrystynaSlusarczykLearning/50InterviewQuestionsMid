var @record = new Record(5);
var baseTypeForRecord = record.GetType().BaseType;

var recordStruct = new RecordStruct(5);
var baseTypeForRecordStruct = recordStruct.GetType().BaseType;

var somePoint = new PointClass(10, 5);
var otherPointEqualByValue = new PointClass(10, 5);
var dict = new Dictionary<PointClass, string>();
dict[somePoint] = "aaa";
dict[otherPointEqualByValue] = "bbb";

var areEqual = somePoint.Equals(otherPointEqualByValue);
Console.WriteLine(somePoint);

var somePointRecord = new PointPositionalRecord(2, 3);
var somePointBythNewY = somePointRecord with { Y = 6 };
var (_, localY) = somePointBythNewY;

var pointNonPositionalRecord = new PointNonPositionalRecord(2, 3);
//Deconstruction doesn't work by defaul for non-positional records
//var (localX, _) = pointNonPositionalRecord;

//also it doesn't work by default for non-positional record structs
var pointNonPositionalRecordStruct = new PointNonPositionalRecordStruct(2, 3);
//var (localXStruct, _) = pointNonPositionalRecordStruct;

var pointReadonlyRecordStructDefaultValues = new PointReadonlyRecordStruct();

Console.ReadKey();


record Record(int a);
record struct RecordStruct(int a);
readonly record struct ReadonlyRecordStruct(int a);

//only record structs can be readonly
//readonly record Rec2(int a);

public readonly record struct PointReadonlyRecordStruct(int X, int Y);

public class PointClass : IEquatable<PointClass>
{
    public int X { get; }
    public int Y { get; }

    public PointClass(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"X:{X}, Y:{Y}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override bool Equals(object? obj)
    {
        return obj is PointClass && Equals((PointClass)obj);
    }

    public bool Equals(PointClass? other)
    {
        return other is not null && other.X == X && other.Y == Y;
    }
}

public record PointPositionalRecord(int X, int Y);

public record PointNonPositionalRecord
{
    public int X { get; set; } //non-positional records can be read-write
    public int Y { get; set; }

    public PointNonPositionalRecord(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int Sum() //we can add methods to records
    {
        return X + Y;
    }
}

public record struct PointNonPositionalRecordStruct
{
    public int X { get; set; }
    public int Y { get; set; }

    public PointNonPositionalRecordStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
}