namespace Decorator_Pattern;
public abstract class Shape
{
    public virtual string AsString() => string.Empty;
}

public class Circle : Shape
{
    private float radius;

    public Circle() : this(0)
    {

    }

    public Circle(float radius)
    {
        this.radius = radius;
    }

    public void Resize(float factor)
    {
        radius *= factor;
    }

    public override string AsString() => $"A circle of radius {radius}";
}

public class Square : Shape
{
    private float side;

    public Square() : this(0)
    {

    }

    public Square(float side)
    {
        this.side = side;
    }

    public override string AsString() => $"A square with side {side}";
}

// dynamic
public class ColoredShape : Shape
{
    private Shape shape;
    private string color;

    public ColoredShape(Shape shape, string color)
    {
        this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
        this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
    }

    public override string AsString() => $"{shape.AsString()} has the color {color}";
}

public class TransparentShape : Shape
{
    private Shape shape;
    private float transparency;

    public TransparentShape(Shape shape, float transparency)
    {
        this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
        this.transparency = transparency;
    }
}