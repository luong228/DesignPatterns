namespace Decorator_Pattern;

public class Dragon : ILizard, IBird
{
    private readonly IBird _bird = new Bird();
    private readonly ILizard _lizard = new Lizard();
    private int weight;
    public int Weight
    {
        get => weight;
        set { weight = value;
            _bird.Weight = value; 
            _lizard.Weight = value; 
        }
    }
    public void Crawl()
    {
        _lizard.Crawl();
    }

    public void Fly()
    {
        _bird.Fly();
    }
}