namespace FacetedBuilder
{
    public class Person
    {
        //address
        public string StreetAddress, Postcode, City;

        //Employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder // facade
    {
        //reference !
        protected Person person = new Person();

        public PersonJobBuilder Works => new(person);
        public PersonAddressBuilder Lives => new(person);
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            this.person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            this.person.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(int amount)
        {
            this.person.AnnualIncome = amount;
            return this;
        }
    }
    public class PersonAddressBuilder : PersonBuilder
    {
        // might not work with a value type!
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }

    }
    public class Demo
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            var person = pb
                .Works.At("Fabrikm")
                    .AsA("Developer")
                    .Earning(123000);
        }
    }
}