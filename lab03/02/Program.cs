class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null) return false;
        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }
}

class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    public string this[int index]
    {
        get
        {
            Car car = cars[index];
            return $"{car.Name} - {car.Engine}";
        }
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public static void Main()
    {
        CarsCatalog catalog = new CarsCatalog();

        Car car1 = new Car("Toyota", "V6", 180);
        Car car2 = new Car("BMW", "V8", 200);
        Car car3 = new Car("Mercedes", "V6", 190);

        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);

        foreach (Car car in catalog.cars)
        {
            Console.WriteLine("Car Name: " + car);
        }

        bool areEqual = car1 == car2;
        bool areNotEqual = car1 != car2;

        Console.WriteLine("Car1 и Car2 равны: " + areEqual);
        Console.WriteLine("Car1 и Car2 не равны: " + areNotEqual);
    }
}
