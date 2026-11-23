using SixLabors.ImageSharp;
public class Worker
{
    public static void run(string[] args)
    {
        string file = args[0];
        Console.WriteLine("Option test was clicked for:");
        Console.WriteLine(file);

        Console.WriteLine($"The extension of this file is: {GetExtension(file)}");

        if(GetExtension(file) == ".webp")
            ConvertWebp(file);
        
        Console.WriteLine("Press any key to close...");
        Console.ReadKey();
    }

    public static string GetExtension(string file)
    {
        return Path.GetExtension(file);
    }

    public static void ConvertWebp(string file)
    {
        string newPath = Path.ChangeExtension(file,".png");
        if(Path.Exists(newPath))
        {
            Console.WriteLine("File already exists");
            return;
        }
        using Image image = Image.Load(file);
        image.SaveAsPng(newPath);
        Console.WriteLine($"File Saved to {newPath}");
    }
}