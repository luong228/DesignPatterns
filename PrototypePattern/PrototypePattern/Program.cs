using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Channels;
using System.Xml.Serialization;

//public interface IPrototype<T>
//{
//    T DeepCopy();
//}
// Serialization way
public static class ExtensionMethods
{
    public static T DeepCopy<T>(this T self)
    {
        var stream = new MemoryStream();
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, self);
        stream.Seek(0, SeekOrigin.Begin);

        object copy = formatter.Deserialize(stream);
        stream.Close();
        return (T)copy;
    }

    public static T DeepCopyXml<T>(this T self)
    {
        using (var stream = new MemoryStream())
        {
            var s = new XmlSerializer(typeof(T));
            s.Serialize(stream, self);
            stream.Position = 0;
            return (T) s.Deserialize(stream);
        }
    }
}
public static class Program
{
    //[Serializable] //Deep Copy
    public class Person// : IPrototype<Person> //: ICloneable
    {
        public string[] Names;
        public Address Address; // The problem with ICloneable is it copy Address recursively or just copy reference ?

        public Person() // DeepCopyXml
        {
            
        }
        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = (string[])other.Names.Clone();
            Address = new Address(other.Address);
        }

        //public Person DeepCopy()
        //{
        //    return new Person((string[])Names.Clone(), Address.DeepCopy());
        //}

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person(Names, (Address)Address.Clone());
        }
    }
    //[Serializable] // DeepCopy
    public class Address//: IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address()// DeepCopyXml
        {
            
        }
        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;  
        }

        public Address(Address other)
        {
            
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        //public Address DeepCopy()
        //{
        //    return new Address(StreetName, HouseNumber);
        //}

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
    static void Main(string[] args)
    {
        var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

        //var jane = (Person)john.Clone();
        //var jane = new Person(john);
        var jane = john.DeepCopyXml();
        jane.Names[0] = "Jane";
        jane.Address.HouseNumber = 321;

        Console.WriteLine(john);
        Console.WriteLine(jane);

    }
}