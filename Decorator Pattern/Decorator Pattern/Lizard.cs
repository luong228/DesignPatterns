namespace Decorator_Pattern;

public class Lizard : ILizard
{
    public int Weight { get; set; }
    public void Crawl()
    {
        Console.WriteLine("Crawl");
    }
}