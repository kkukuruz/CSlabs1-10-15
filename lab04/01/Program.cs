class MyMatrix
{
    private int[,] matrix;

    public int Rows;
    public int Columns;

    public MyMatrix(int m, int n)
    {
        Rows = m;
        Columns = n;
        matrix = new int[m, n];
        Random rand = new Random();

        Console.WriteLine("Введите минимальное значение для случайных чисел:");
        int minValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите максимальное значение для случайных чисел:");
        int maxValue = int.Parse(Console.ReadLine());

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rand.Next(minValue, maxValue);
            }
        }
    }

    public int this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new InvalidOperationException("Матрицы должны иметь одинаковые размеры для сложения.");
        }

        MyMatrix result = new MyMatrix(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new InvalidOperationException("Матрицы должны иметь одинаковые размеры для вычитания.");
        }

        MyMatrix result = new MyMatrix(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Columns != matrix2.Rows)
        {
            throw new InvalidOperationException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы для умножения.");
        }

        MyMatrix result = new MyMatrix(matrix1.Rows, matrix2.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix2.Columns; j++)
            {
                for (int k = 0; k < matrix1.Columns; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество строк матрицы:");
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов матрицы:");
        int n = int.Parse(Console.ReadLine());

        MyMatrix matrix1 = new MyMatrix(m, n);
        MyMatrix matrix2 = new MyMatrix(m, n);

        MyMatrix resultMatrixSum = matrix1 + matrix2;
        MyMatrix resultMatrixSubtract = matrix1 - matrix2;
        MyMatrix resultMatrixMultiply = matrix1 * matrix2;

        Console.WriteLine("Результат сложения матриц:");
        PrintMatrix(resultMatrixSum);

        Console.WriteLine("Результат вычитания матриц:");
        PrintMatrix(resultMatrixSubtract);

        Console.WriteLine("Результат умножения матриц:");
        PrintMatrix(resultMatrixMultiply);

        int element = matrix1[0, 0];
    }

    static void PrintMatrix(MyMatrix matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}