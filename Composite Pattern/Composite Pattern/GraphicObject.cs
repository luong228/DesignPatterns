using System.Text;

namespace Composite_Pattern;

public class GraphicObject
{

    public virtual string Name { get; set; } = "Group";
    public string? Color;
    private readonly Lazy<List<GraphicObject>> _children = new Lazy<List<GraphicObject>>();
    public List<GraphicObject> Children => _children.Value;

    private void Print(StringBuilder sb, int depth)
    {
        sb.Append(new string('*', depth))
            .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : Color)
            .AppendLine(Name);
        foreach (var graphicObject in Children)
        {
            graphicObject.Print(sb, depth+1);
        }
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        Print(sb, 0);
        return sb.ToString();
    }
}