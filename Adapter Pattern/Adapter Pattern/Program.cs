using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

public class Point
{
    public float x, y;

    public Point(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Line
{
    public Point Start, End;

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }
}

public class VectorObject : Collection<Line>
{

}

public class VectorRectangle : VectorObject
{
    public VectorRectangle(float x, float y, float width, float height)
    {
        Add(new Line(new Point(x, y), new Point(x + width, y)));
        Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
        Add(new Line(new Point(x, y), new Point(x, y + height)));
        Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
    }
}

public class LineToPointAdapter : Collection<Point>
{
    private static int count;
    public LineToPointAdapter(Line line)
    {
        Console.WriteLine($"{++count}: Generating points for line [{line.Start.x}{line.Start.y}]-[{line.End.x}{line.End.y}]");
    }
}
public class Demo
{
    private static readonly List<VectorObject> vectorObjects = new List<VectorObject>
    {
        new VectorRectangle(1, 1, 10, 10),
        new VectorRectangle(3,3,6,6)
    };

    public static void DrawPoint(Point p)
    {
        Console.WriteLine(".");
    }
    static void Main(string[] args)
    {

    }
}