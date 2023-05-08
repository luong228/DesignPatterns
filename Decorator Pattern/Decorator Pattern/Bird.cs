namespace Decorator_Pattern;

public class Bird : IBird
{
    public int Weight { get; set; }
    public void Fly()
    {
        Console.WriteLine("Fly");
    }
}