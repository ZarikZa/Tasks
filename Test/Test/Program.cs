using System.Runtime.Serialization.Formatters;
using Test;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Что вы хотите сделать??");
            Console.WriteLine("1. Количество программистов \n2. Сумма соседей \n3. Матрица \n4. Проверка пароля \n5. Числа Фибоначчи \n6. Красивая табличка \n7. Фигуры \n8. Диагонали\n9. Выйти");
            string vibor = Console.ReadLine();
            switch (vibor)
            {
                case "1":
                    Console.Write("Введите количество программистов: ");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine($"В комнате {n} {FirstTask(n)}");
                    break;
                case "2":
                    Console.Write("Введите список чисел через пробел: ");
                    string input = Console.ReadLine();
                    int[] numbers = input.Split(' ').Select(int.Parse).ToArray();
                    if (numbers.Length == 1)
                    {
                        Console.WriteLine(numbers[0]);
                    }
                    else
                    {
                        int[] result = SecondTask(numbers);
                        Console.WriteLine(string.Join(" ", result));
                    }
                    break;
                case "3":
                    Console.Write("Введите число n: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    var matrix = ThirdTask(n);
                    Console.WriteLine("Ваша матрица");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case "4":
                    Console.WriteLine("Введите пароль");
                    string pass = Console.ReadLine();
                    check_password(pass);
                    break;
                case "5":
                    Console.WriteLine("Введите количество цифр");
                    try
                    {
                        int F = Convert.ToInt32(Console.ReadLine());
                        Fibanachi(F);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Это не число");
                    }
                    break;
                case "6":
                    Table();
                    break;
                case "7":
                    CalculeteP();
                    break;
                case "8":
                    Console.WriteLine("Введите количество углов");
                    var chislo = Console.ReadLine();
                    bool proverka = int.TryParse(chislo, out _);
                    if (proverka == true)
                    {
                        Console.WriteLine(Diag(Convert.ToInt32(chislo)));
                    }
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
            }
        }
        
    }

    public static string FirstTask(int n)
    {
        if (n >= 11 && n <= 14 || n % 10 == 0 || n % 10 >= 5 && n % 10 <= 9)
        {
            return "программистов";
        }
        else if (n % 10 == 1)
        {
            return "программист";
        }
        else
        {
            return "программиста";
        }
    }

    public static int[] SecondTask(int[] numbers)
    {
        int[] result = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            int left = numbers[(i - 1 + numbers.Length) % numbers.Length];
            int right = numbers[(i + 1) % numbers.Length];
            result[i] = left + right;
        }
        return result;
    }
    
    public static int[,] ThirdTask(int n)
    {
        int[,] matrix = new int[n,n];
        int chisla = 1;
        for (int i = 0;i < n;i++)
        {
            for (int j = 0;j < n; j++)
            {
                matrix[i, j] = chisla++;
            }
        }
        return matrix;
    }

    public static void check_password(string password)
    {
        int result = 0;
        int digits = 0;
        foreach (char c in password)
        {
            if (char.IsDigit(c))
            {
                digits++;
                if (digits >= 3) 
                {
                    result++;
                    break; 
                }
            }
            else if (char.IsUpper(c))
            {
                result++;
            }
            else if ("!@#$%*".Contains(c))
            {
                result++;
            }
        }
        if(result >= 3)
        {
            Console.WriteLine("Хорош!!!");
        }
        else
        {
            Console.WriteLine("Ненадёжный пароль");
        }
    }
    public static void Fibanachi(int n)
    {
        int i1 = 0;
        int i2 = 1;
        int chislo = 0;
        Console.WriteLine($"Число Фибоначчи №0: {i1}"); 
        Console.WriteLine($"Число Фибоначчи №1: {i2}");
        for (int i = 0; i + 2 < n; i++)
        {
            chislo = i1 + i2;
            i1 = i2;
            i2 = chislo;
            Console.WriteLine($"Число фибаначи №{i+2}: {chislo}");
        }
    }

    public static void Table()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.Write("   | ");
        for (int i = 1; i <= 9; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{i,3}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" |");
        }
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------");
        for (int i = 1; i <= 9; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{i,2}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | ");
            for (int j = 1; j <= 9; j++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{i * j,3}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" |");
            }
            Console.WriteLine();
        }
    }

    public static void CalculeteP()
    {
        List<object> shapes = new List<object>()
        {
            new Rectangle(5, 10),
            new Square(7),
            new Circle(3),
            new Triangle(3, 4, 5),
            new Square(4),
            new Rectangle(8, 2),
            new Circle(2.5)
        };

        foreach (object shape in shapes)
        {
            if (shape is Rectangle rectangle)
            {
                Console.WriteLine($"Прямоугольник (длина: {rectangle.Length}, ширина: {rectangle.Width}) - Периметр: {rectangle.CalculatePerimeter()}");
            }
            else if (shape is Square square)
            {
                Console.WriteLine($"Квадрат (сторона: {square.Side}) - Периметр: {square.CalculatePerimeter()}");
            }
            else if (shape is Circle circle)
            {
                Console.WriteLine($"Круг (радиус: {circle.Radius}) - Периметр: {circle.CalculatePerimeter()}");
            }
            else if (shape is Triangle triangle)
            {
                Console.WriteLine($"Треугольник (стороны: {triangle.Side1}, {triangle.Side2}, {triangle.Side3}) - Периметр: {triangle.CalculatePerimeter()}");
            }
        }
    }
    public static int Diag(int n)
    {
        return (int)(0.5 * n * (n - 3));
    }
}