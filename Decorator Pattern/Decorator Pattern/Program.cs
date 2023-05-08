namespace Decorator_Pattern;

//Decorator pattern

public interface IReportingService
{
    void Report();

}

public class ReportingService : IReportingService
{

    public void Report()
    {
        Console.WriteLine("Report");
    }
}

public class ReportingServiceWithLogging : IReportingService
{
    private readonly IReportingService _reportingService;

    public ReportingServiceWithLogging(IReportingService reportingService)
    {
        _reportingService = reportingService;
    }
    public void Report()
    {
        Console.WriteLine("Logging");
        _reportingService.Report();
        Console.WriteLine("End Logging");
    }
}
public static class Program
{

    static void Main(string[] args)
    {
        var cb = new CodeBuilder();

        cb.AppendLine("casasd");
        cb.AppendLine("{");
        cb.AppendLine("}");

        Console.WriteLine(cb);

        MyStringBuilder sb = "hello ";
        sb += "world";
        Console.WriteLine(sb);
        // Multiple Inheritance
        var d = new Dragon();
        d.Crawl();
        d.Fly();
        // End
        //Dynamic Decorator
        var square = new Square(1.23f);
        Console.WriteLine(square.AsString());

        var redSquare = new ColoredShape(square, "red");
        Console.WriteLine(redSquare.AsString());

        var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
        Console.WriteLine(redHalfTransparentSquare.AsString());
        //End Dynamic
        //Decorator with DI

    }
}