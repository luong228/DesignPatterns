namespace Composite_Pattern;

static class Program
{
    static void Main(string[] args)
    {
        // Geometric Shapes
        var drawing = new GraphicObject() { Name = "My Drawing" };
        drawing.Children.Add(new Circle(){Color="Red"});
        drawing.Children.Add(new Square() { Color = "Blue" });

        var group = new GraphicObject();
        group.Children.Add(new Square() { Color = "Yellow" });
        group.Children.Add(new Circle() { Color = "Green" });
        drawing.Children.Add(group);
        Console.WriteLine(drawing);
        //End Geometric Shapes
        //Folder
        var rootFolder = new Folder() { Name = "Root Folder" };
        var folder1 = new Folder() { Name = "Folder 1" };
        var folder2 = new Folder() { Name = "Folder 2" };
        var file1 = new File { Name = "File 1" };
        var file2 = new File { Name = "File 2" };

        rootFolder.Add(folder1);
        rootFolder.Add(folder2);
        folder1.Add(file1);
        folder2.Add(file2);

        rootFolder.Display(0);
        //End Folder
        //Neuron Networks
        var neuron1 = new Neuron();
        var neuron2 = new Neuron();

        var layer1 = new NeuronLayer();
        var layer2 = new NeuronLayer();

        neuron1.ConnectTo(neuron1);

        //End Neuron Networks

    }
}