struct Vector
{
    public double X, Y, Z;

    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector operator -(Vector v1, Vector v2)
    {
        return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    public static Vector operator *(double scalar, Vector v)
    {
        return v * scalar;
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.Length() == v2.Length();
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return v1.Length() != v2.Length();
    }

    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }
}

class Program
{
    static void Main()
    {
        Vector vector1 = new Vector(1, 2, 3);
        Vector vector2 = new Vector(4, 5, 6);

        Vector sum = vector1 + vector2;
        Vector difference = vector1 - vector2;

        Console.WriteLine("Сумма векторов: X={0}, Y={1}, Z={2}", sum.X, sum.Y, sum.Z);
        Console.WriteLine("Разница векторов: X={0}, Y={1}, Z={2}", difference.X, difference.Y, difference.Z);

        Vector scaled = vector1 * 2.5;
        Vector scaledByScalar = 3.0 * vector2;

        Console.WriteLine("Умножение вектора на число: X={0}, Y={1}, Z={2}", scaled.X, scaled.Y, scaled.Z);
        Console.WriteLine("Умножение числа на вектор: X={0}, Y={1}, Z={2}", scaledByScalar.X, scaledByScalar.Y, scaledByScalar.Z);

        bool areEqual = vector1 == vector2;
        bool areNotEqual = vector1 != vector2;

        Console.WriteLine("Векторы равны: {0}", areEqual);
        Console.WriteLine("Векторы не равны: {0}", areNotEqual);
    }
}
