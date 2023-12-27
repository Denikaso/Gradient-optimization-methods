using Gradient_optimization_methods;
using System.Numerics;

static double Function1(Vector2 x)
{
    return 5 - Math.Pow(x.X - 4, 2) - Math.Pow(x.Y - 5, 2);
}

static Vector2 Gradient1(Vector2 x)
{
    double df_dx1 = 8 - 2 * x.X;
    double df_dx2 = -2 * (x.Y - 5);
    return new Vector2((float)df_dx1, (float)df_dx2);
}

static double Function2(Vector2 x)
{
    return 2 * Math.Pow(x.X, 2) - x.X * x.Y + Math.Pow(x.Y, 2) - x.X - x.Y + 1;
}

static Vector2 Gradient2(Vector2 x)
{
    double df_dx1 = 4 * x.X - x.Y - 1;
    double df_dx2 = -x.X + 2 * x.Y - 1;
    return new Vector2((float)df_dx1, (float)df_dx2);
}


float initialX1, initialX2, alpha, epsilon;

Console.Write("Введите начальное значение x1: ");
initialX1 = float.Parse(Console.ReadLine());

Console.Write("Введите начальное значение x2: ");
initialX2 = float.Parse(Console.ReadLine());

Console.Write("Введите шаг: ");
alpha = float.Parse(Console.ReadLine());

Console.Write("Введите точность: ");
epsilon = float.Parse(Console.ReadLine());

Vector2 initialPoint = new Vector2(initialX1, initialX2);
bool finish;
Vector2 minPointBacktracking = GradientDescentMethod.BacktrackingLineSearch(Function1, Gradient1, initialPoint, epsilon, alpha, out finish);

if(finish)
{
    Console.WriteLine("\nМетод градиента с дроблением шага:");
    Console.WriteLine($"Минимум функции: {Function2(minPointBacktracking)}");
    Console.WriteLine($"Точка минимума: {minPointBacktracking}");
}