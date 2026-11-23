public class Worker
{
    public static void run(string[] args)
    {
        Console.WriteLine("Option test was clicked for:");
        Console.WriteLine(args[0]);

        Console.WriteLine("Press any key to close...");
        Console.ReadKey();
    }
}