namespace OpenClosed
{
    public enum Color
    {
        Red,Green, Blue, Magenta,
    }

    public enum Size
    {
        Small, Medium, Blue, Magenta,
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if(p.Size == size) yield return p;
            }
        }
        //Violate Open/Closed principle when modify this function after extend project
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if(p.Color == color) yield return p;
            }
        }
        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var p in products)
            {
                if (p.Color == color && p.Size == size) yield return p;
            }
        }
    }

    public interface ISpectification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpectification<T> spec);
    }

    public class ColorSpectification : ISpectification<Product>
    {
        private Color color;

        public ColorSpectification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpectification : ISpectification<Product>
    {
        private Size size;

        public SizeSpectification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class AndSpectification<T> : ISpectification<T>
    {
        private ISpectification<T> first, second;

        public AndSpectification(ISpectification<T> first, ISpectification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpectification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i)) yield return i;
            }
        }
    }
    public class Demo
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Blue, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Medium);
            var house = new Product("House", Color.Blue, Size.Medium);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green Products (old)");

            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }

            var bf = new BetterFilter();

            Console.WriteLine("Green Products (new)");
            foreach (var b in bf.Filter(products, new ColorSpectification(Color.Green)))
            {
                Console.WriteLine($" - {b.Name} is green");
            }
            Console.WriteLine("Blue and Medium items (new)");
            foreach (var b in bf.Filter(
                         products,
                         new AndSpectification<Product>(
                             new ColorSpectification(Color.Blue), 
                             new SizeSpectification(Size.Medium))
                         )
                     )
            {
                Console.WriteLine($"- {b.Name} is Blue and Medium");
            }
        }
    }
}