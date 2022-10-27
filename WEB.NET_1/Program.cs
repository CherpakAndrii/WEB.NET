using OwnListLib;

public static class Program
{
    public static void Main()
    {
        OwnList<int> list = new OwnList<int>();
        list.OnAddElement += (obj, e) => Console.WriteLine("The element is added to list!");
        list.OnRemoveElement += (obj, e) => Console.WriteLine("The element is removed from list!");
        list.OnClearList += (obj, e) => Console.WriteLine("The list is cleared!");
        
        list.Add(5);
        Console.WriteLine("list.Add(5);");
        Print(list);

        list.Add(8);
        Console.WriteLine("list.Add(8);");
        Print(list);
        
        for (int i = 0; i < 25; i++)
        {
            list.Add(i);
        }
        Console.WriteLine("for (int i = 0; i < 25; i++) list.Add(i);");
        Print(list);
        
        list.Remove(8);
        Console.WriteLine("list.Remove(8);");
        Print(list);
        
        list.Insert(2, 125);
        Console.WriteLine("list.Insert(2, 125);");
        Print(list);
        
        list.Insert(0, 126);
        Console.WriteLine("list.Insert(0, 126);");
        Print(list);
        
        list.Insert(1, 127);
        Console.WriteLine("list.Insert(1, 127);");
        Print(list);
        
        list.Insert(28, 128);
        Console.WriteLine("list.Insert(28, 128);");
        Print(list);
        
        list.Insert(30, 129);
        Console.WriteLine("list.Insert(30, 129);");
        Print(list);
        
        list.RemoveAt(2);
        Console.WriteLine("list.RemoveAt(2);");
        Print(list);

        int[] arr = new int[list.Count];
        list.CopyTo(arr, 0);
        

        list.Clear();
        Console.WriteLine("list.Clear();");
        Print(list);
    }

    private static void Print(OwnList<int> list)
    {
        Console.WriteLine("Length = "+list.Count);
        foreach (int el in list)
        {
            Console.WriteLine(el);
        }
        Console.WriteLine("\n");
    }
}
