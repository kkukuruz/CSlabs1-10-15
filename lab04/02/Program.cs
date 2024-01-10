class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }
}

class CarComparer : IComparer<Car>
{
    private string sortBy;
    public CarComparer(string sortBy)
    {
        this.sortBy = sortBy;
    }

    public int Compare(Car x, Car y)
    {
        switch (sortBy)
        {
            case "Name":
                return string.Compare(x.Name, y.Name);
            case "ProductionYear":
                return x.ProductionYear.CompareTo(y.ProductionYear);
            case "MaxSpeed":
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            default:
                throw new ArgumentException("Неверный параметр сортировки.");
        }
    }
}

class Programm
{
    static void Main()
    {
        Car[] cars = new Car[]
        {
              new Car { Name = "Car1", ProductionYear = 2020, MaxSpeed = 200 },
            new Car { Name = "Car3", ProductionYear = 2018, MaxSpeed = 180 },
            new Car { Name = "Car2", ProductionYear = 2019, MaxSpeed = 220 },
        };

        Console.WriteLine("Выберите параметр сортировки (Name, ProductionYear, MaxSpeed):");
        string sortBy = Console.ReadLine();

        Array.Sort(cars, new CarComparer(sortBy));

        Console.WriteLine("Отсортированный массив:");
        foreach (var car in cars)
        {
            Console.WriteLine($"Name: {car.Name}, ProductionYear: {car.ProductionYear}, MaxSpeed: {car.MaxSpeed}");
        }
    }
}