using System;
namespace lab01
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Figure
    {
        private Point[] points;
        public string Name { get; set; }

        public Figure(params Point[] points)
        {
            if (points.Length < 3 || points.Length > 5)
                throw new ArgumentException("Фигура должна состоять из 3-5 точек.");

            this.points = points;
            Name = "";
        }

        public double LengthSide(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }
        public void PerimeterCalculator()
        {
            double perimeter = 0;
            for (int i = 0; i < points.Length; i++)
            {
                int nextIndex = (i + 1) % points.Length;
                perimeter += LengthSide(points[i], points[nextIndex]);
            }

            Console.WriteLine($"Название фигуры: {Name}");
            Console.WriteLine($"Периметр фигуры: {perimeter}");

        }
    }

    class Program
    {
        static void Main()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 0);

            Figure triangle = new Figure(p1, p2, p3);
            triangle.Name = "Треугольник";
            triangle.PerimeterCalculator();
        }
}
}