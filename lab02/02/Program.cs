class Vehicle
{
    private double coordinates;
    public double Coordinates
    {
        get { return coordinates; }
        set { coordinates = value; }
    }

    public double Price { get; set; }
    public double Speed { get; set; }
    public int Year { get; set; }

    public Vehicle(double coordinates, double price, double speed, int year)
    {
        this.coordinates = coordinates;
        Price = price;
        Speed = speed;
        Year = year;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Coordinates: {coordinates}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Speed: {Speed}");
        Console.WriteLine($"Year: {Year}");
    }
}

class Plane : Vehicle
{
    public double Altitude { get; set; }
    public int Passengers { get; set; }

    public Plane(double coordinates, double price, double speed, int year, double altitude, int passengers)
        : base(coordinates, price, speed, year)
    {
        Altitude = altitude;
        Passengers = passengers;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Altitude: {Altitude}");
        Console.WriteLine($"Passengers: {Passengers}");
    }
}

class Car : Vehicle
{
    public Car(double coordinates, double price, double speed, int year)
        : base(coordinates, price, speed, year)
    {
    }
}

class Ship : Vehicle
{
    public int Passengers { get; set; }
    public string Port { get; set; }

    public Ship(double coordinates, double price, double speed, int year, int passengers, string port)
        : base(coordinates, price, speed, year)
    {
        Passengers = passengers;
        Port = port;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Passengers: {Passengers}");
        Console.WriteLine($"Port: {Port}");
    }
}

class Program
{
    static void Main()
    {
        Vehicle vehicle1 = new Plane(1000, 1000000, 600, 2020, 30000, 150);
        Vehicle vehicle2 = new Car(500, 30000, 150, 2022);
        Vehicle vehicle3 = new Ship(2000, 800000, 50, 2018, 3000, "New York");

        vehicle1.ShowInfo();
        Console.WriteLine();
        vehicle2.ShowInfo();
        Console.WriteLine();
        vehicle3.ShowInfo();
    }
}
