using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Gradient_optimization_methods
{
    internal class GradientDescentMethod
    {        
        public delegate double CostFunction(Vector2 x);
        public delegate Vector2 GradientFunction(Vector2 x);

        static public Vector2 BacktrackingLineSearch(CostFunction costFunction, GradientFunction gradient, Vector2 startingPoint, float epsilon, float userAlpha, out bool finish, bool isMinimization = true)
        {
            finish = true;
            Vector2 x = startingPoint;
            float alpha = userAlpha; // Используем значение, введенное пользователем
            float beta = 0.5f; // Коэффициент уменьшения шага
            int iteration = 0;

            while (gradient(x).Length() > epsilon)
            {
                iteration++;                
                // Вычисляем производные в текущей точке
                Vector2 grad = gradient(x);

                // Вычисляем модуль градиента
                float gradMagnitude = grad.Length();

                // Проверка, чтобы избежать деления на ноль
                if (gradMagnitude > float.Epsilon)
                {                    
                    // Вычисляем новую точку с учетом модуля градиента
                    Vector2 newX = x - alpha * (grad / gradMagnitude);

                    // Вычисляем значение функции в новых точках
                    double newCost = costFunction(newX);
                    double oldCost = costFunction(x);

                    if (iteration == 10000)
                    {
                        Console.WriteLine("Прошло 10к итераций, ответ не получен. Текущие значения:");
                        Console.WriteLine($"Минимум функции: {newCost}");
                        Console.WriteLine($"Точка минимума: {x}");
                        finish = false;
                        break;
                    }

                    // Условие Вольфа для минимизации
                    while (isMinimization ? (newCost >= oldCost + beta * alpha * Vector2.Dot(grad, newX - x)) : (newCost <= oldCost + beta * alpha * Vector2.Dot(grad, newX - x)))
                    {
                        alpha *= 0.5f;

                        // Пересчитываем новую точку
                        newX = x - alpha * (grad / gradMagnitude);

                        // Пересчитываем значение функции в новых точках
                        newCost = costFunction(newX);
                    }

                    x = newX;
                }
                else
                {
                    break;
                }
            }

            return x;
        }


    }
}
