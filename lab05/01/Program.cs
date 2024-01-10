class MyMatrix
{
    private int[,] matrix;
    private Random random;
    
    public MyMatrix(int m, int n, int minValue, int maxValue)
    {
        
        matrix = new int[m, n];
        random = new Random();

        Fill(minValue, maxValue);
    }
    public double this[int row, int column]
    {
        get { return matrix[row, column]; }
        set { matrix[row, column] = (int)value; }
    }

    public void Fill(int minValue, int maxValue)
    {

        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            for(int j = 0; j<matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    public void ChangeSize(int M, int N, int minValue, int maxValue)
    {
        int[,] newMatrix = new int[M, N];

        for(int i = 0; i < Math.Min(matrix.GetLength(0), M); i++)
        {
            for(int j = 0; j<Math.Max(matrix.GetLength(1), N); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        matrix = newMatrix;

        if(M > matrix.GetLength(0) || N > matrix.GetLength(1))
        {
            for(int i = 0; i<M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if(i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
                    {
                        matrix[i, j] = random.Next(minValue, maxValue);
                    }
                }
            }
        }
    }

    public void ShowPartialy(int startRow, int endRow, int startCol, int endCol)
    {
        for (int i = startRow; i <= endRow && i < matrix.GetLength(0); i++)
        {
            for (int j = startCol; j <= endCol && j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }


    public void Show()
    {
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }


    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество строк матрицы:");
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов матрицы:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите минимальное значение для заполнения матрицы:");
        int minValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите максимальное значение для заполнения матрицы:");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix myMatrix = new MyMatrix(m, n, minValue, maxValue);

        Console.WriteLine("Исходная матрица:");
        myMatrix.Show();

        Console.WriteLine("Изменение размера матрицы (новые строки и столбцы):");
        Console.WriteLine("Введите новое количество строк:");
        int M = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите новое количество столбцов:");
        int N = int.Parse(Console.ReadLine());

        myMatrix.ChangeSize(M, N, minValue, maxValue);

        Console.WriteLine("Матрица после изменения размера:");
        myMatrix.Show();

        Console.WriteLine("Введите индексы для отображения части матрицы:");
        Console.WriteLine("Начальная строка:");
        int startRow = int.Parse(Console.ReadLine());
        Console.WriteLine("Конечная строка:");
        int endRow = int.Parse(Console.ReadLine());
        Console.WriteLine("Начальный столбец:");
        int startCol = int.Parse(Console.ReadLine());
        Console.WriteLine("Конечный столбец:");
        int endCol = int.Parse(Console.ReadLine());

        Console.WriteLine("Часть матрицы:");
        myMatrix.ShowPartialy(startRow, endRow, startCol, endCol);
    }
}

