namespace Stepwise
{
    public enum CarType
    {
        Seden,
        Crossover
    }

    public class Car
    {
        public CarType Type;
        public int WheelSize;
    }

    public interface ISpectifyCarType
    {
        ISpectifyWheelSize OfType(CarType type);
    }

    public interface ISpectifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        private class Impl :
            ISpectifyCarType, 
            ISpectifyWheelSize,
            IBuildCar
        {
            private Car car = new Car();
            public ISpectifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                    case CarType.Seden when size < 15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
                }
                car.WheelSize = size;
                return this;
            }

            public Car Build()
            {
                return car;
            }
        }
        public static ISpectifyCarType Create()
        {
            return new Impl();
        }
    }
    public class Demo
    {
        static void Main(string[] args)
        {
            var car = CarBuilder.Create() // ISpectifyCarType
                .OfType(CarType.Crossover) // ISpectifyWheelSize
                .WithWheels(16) // IBuildCar
                .Build();
        }
    }
}