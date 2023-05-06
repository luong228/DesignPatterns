using System.Collections;

namespace Composite_Pattern;
public static class ExtensionMethods
{
    public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
    {
        foreach (var from in self)
        foreach (var to in other)
        {
            from.Out.Add(to);
            to.In.Add(from);
        }
    }
}
public class Neuron : IEnumerable<Neuron>
{
    public float Value;
    public List<Neuron> In = new(), Out = new();

    //public void ConnectTo(Neuron other)
    //{
    //    Out.Add(other);
    //    other.In.Add(this);
    //}

    public IEnumerator<Neuron> GetEnumerator()
    {
        yield return this; 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}