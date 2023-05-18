using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter_Pattern
{
    public class Person
    {
        private string name;
        private string gender;
        private string maritalStatus;

        public Person(string name, string gender, string maritalStatus)
        {
            this.name = name;
            this.gender = gender;
            this.maritalStatus = maritalStatus;
        }

        public string Name
        {
            get { return name; }
        }
        public string Gender
        {
            get { return gender; }
        }
        public string MaritalStatus
        {
            get { return maritalStatus; }
        }
    }
    public interface ICriteria
    {
        List<Person> MeetCriteria(List<Person> persons);
    }

    public class CriteriaMale : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();

            foreach (Person person in persons)
            {
                if (person.Gender.Equals("MALE", StringComparison.OrdinalIgnoreCase))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }

    public class CriteriaFemale : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> femalePersons = new List<Person>();

            foreach (Person person in persons)
            {
                if (person.Gender.Equals("FEMALE", StringComparison.OrdinalIgnoreCase))
                {
                    femalePersons.Add(person);
                }
            }
            return femalePersons;
        }
    }

    public class CriteriaSingle : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> singlePersons = new List<Person>();

            foreach (Person person in persons)
            {
                if (person.MaritalStatus.Equals("SINGLE", StringComparison.OrdinalIgnoreCase))
                {
                    singlePersons.Add(person);
                }
            }
            return singlePersons;
        }
    }

    public class AndCriteria : ICriteria
    {
        private ICriteria _criteria;
        private ICriteria _otherCriteria;

        public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this._criteria = criteria;
            this._otherCriteria = otherCriteria;
        }

        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = _criteria.MeetCriteria(persons);
            return _otherCriteria.MeetCriteria(firstCriteriaPersons);
        }
    }

    public class OrCriteria : ICriteria
    {
        private ICriteria _criteria;
        private ICriteria _otherCriteria;

        public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this._criteria = criteria;
            this._otherCriteria = otherCriteria;
        }

        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = _criteria.MeetCriteria(persons);
            List<Person> otherCriteriaPersons = _otherCriteria.MeetCriteria(persons);

            foreach (Person person in otherCriteriaPersons)
            {
                if (!firstCriteriaPersons.Contains(person))
                {
                    firstCriteriaPersons.Add(person);
                }
            }
            return firstCriteriaPersons;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("Robert", "Male", "Single"));
            persons.Add(new Person("John", "Male", "Married"));
            persons.Add(new Person("Laura", "Female", "Married"));
            persons.Add(new Person("Diana", "Female", "Single"));
            persons.Add(new Person("Mike", "Male", "Single"));
            persons.Add(new Person("Bobby", "Male", "Single"));

            ICriteria male = new CriteriaMale();
            ICriteria female = new CriteriaFemale();
            ICriteria single = new CriteriaSingle();
            ICriteria singleMale = new AndCriteria(single, male);
            ICriteria singleOrFemale = new OrCriteria(single, female);

            Console.WriteLine("Males: ");
            PrintPersons(male.MeetCriteria(persons));

            Console.WriteLine("\nFemales: ");
            PrintPersons(female.MeetCriteria(persons));

            Console.WriteLine("\nSingle Males: ");
            PrintPersons(singleMale.MeetCriteria(persons));

            Console.WriteLine("\nSingle Or Females: ");
            PrintPersons(singleOrFemale.MeetCriteria(persons));
        }
        public static void PrintPersons(List<Person> localPersons)
        {
            foreach (var person in localPersons)
            {
                Console.WriteLine("Person : [ Name : " + person.Name
                                                       + ", Gender : " + person.Gender
                                                       + ", Marital Status : " + person.MaritalStatus
                                                       + " ]");
            }
        }
    }
}
