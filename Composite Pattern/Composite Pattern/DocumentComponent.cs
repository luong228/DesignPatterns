namespace Composite_Pattern;

public abstract class DocumentComponent
{
    public string Name { get; set; }
    public abstract void Add(DocumentComponent component);
    public abstract void Remove(DocumentComponent component);
    public abstract void Display(int depth);
}