class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }
}

class CarCatalog : IEnumerable<Car>
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public IEnumerable<Car> ReverseIterator()
    {
        for (int i = cars.Count - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<Car> GetCarsByYear(int year)
    {
        foreach (var car in cars)
        {
            if (car.ProductionYear == year)
                yield return car;
        }
    }

    public IEnumerable<Car> GetCarsByMaxSpeed(int maxSpeed)
    {
        foreach (var car in cars)
        {
            if (car.MaxSpeed == maxSpeed)
                yield return car;
        }
    }


    public IEnumerator<Car> GetEnumerator()
    {
        return cars.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        CarCatalog catalog = new CarCatalog();

        catalog.AddCar(new Car { Name = "Car1", ProductionYear = 2020, MaxSpeed = 200 });
        catalog.AddCar(new Car { Name = "Car2", ProductionYear = 2018, MaxSpeed = 180 });
        catalog.AddCar(new Car { Name = "Car3", ProductionYear = 2010, MaxSpeed = 200 });
        catalog.AddCar(new Car { Name = "Car4", ProductionYear = 2020, MaxSpeed = 200 });

        Console.WriteLine("Прямой проход от первого до последнего:");
        foreach (var car in catalog)
        {
            Console.WriteLine($"Name: {car.Name}, ProductionYear: {car.ProductionYear}, MaxSpeed: {car.MaxSpeed}");
        }

        Console.WriteLine("\nОбратный проход от последнего к первому:");
        foreach (var car in catalog.ReverseIterator())
        {
            Console.WriteLine($"Name: {car.Name}, ProductionYear: {car.ProductionYear}, MaxSpeed: {car.MaxSpeed}");
        }

        foreach (var car in catalog.GetCarsByYear(2020))
        {
            Console.WriteLine(car.Name);
        }

        Console.WriteLine();

        foreach (var car in catalog.GetCarsByMaxSpeed(200))
        {
            Console.WriteLine(car.Name);
        }
    }
}