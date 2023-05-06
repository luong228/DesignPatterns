namespace Composite_Pattern;

public class File : DocumentComponent
{
    public override void Add(DocumentComponent component)
    {
        Console.WriteLine("Cannot add to a file.");
    }

    public override void Remove(DocumentComponent component)
    {
        Console.WriteLine("Cannot remove from a file.");
    }

    public override void Display(int depth)
    {
        Console.WriteLine($"{new string('*', depth)}File: " + this.Name);
    }
}