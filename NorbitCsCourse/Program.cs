using Library3;

public class Program
{
    public static void Main()
    {
        var a = new DynamicArray<int>();
        Console.WriteLine(a.Capacity);
        a.Add(5);
        Console.WriteLine(a.GetElement(0));
        for (var i = 0; i < 5; i++)
        {
            a.Add(i);
        }
        a.Insert(0, 10);
        Console.WriteLine(a.GetElement(0));
    }
}
