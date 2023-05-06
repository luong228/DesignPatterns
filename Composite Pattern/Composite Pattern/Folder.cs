namespace Composite_Pattern;

public class Folder : DocumentComponent
{
    private List<DocumentComponent> _components = new List<DocumentComponent>();

    public override void Add(DocumentComponent component)
    {
        _components.Add(component);
    }

    public override void Remove(DocumentComponent component)
    {
        _components.Remove(component);
    }

    public override void Display(int depth)
    {
        Console.WriteLine($"{new string('*', depth)}Folder: " + this.Name);
        foreach (var component in _components)
        {
            component.Display(depth + 1);
        }
    }
}