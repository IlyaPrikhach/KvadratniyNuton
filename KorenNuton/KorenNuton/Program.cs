using System;

namespace KorenNuton
{
    class Program
    {
        static void Main(string[] args)
        {
            double A, E;
            int n;
            вводДанных(out A, out E, out n);  
            double x = начальноеПриближение(A, n);
            double X = методНьютона(x, A, n, E);
            Console.WriteLine("Ваш корень равен " + X);
            double MP = Math.Pow(A, 1.0 / n);
            Console.WriteLine("Через Math.Pow " + MP);
            Console.ReadLine();
        }

        static void вводДанных(out double A, out double E, out int n)
        {
            try
            {
                Console.WriteLine("Введите степень корня n, значение подкоренного выражения A и точность E");
                string[] аргументы = Console.Replace('.',',').ReadLine().Split(' ');
                n = Convert.ToInt32(аргументы[0]);
                A = double.Parse(аргументы[1]);
                E = double.Parse(аргументы[2]);
            }
            catch {
                Console.WriteLine("неверные данные");
                вводДанных(out A, out E, out n);
            }
        }

        static double начальноеПриближение(double A, int n)
        {
            double x0 = A * 0.3 / n;
            return x0;
        }

        static double методНьютона(double x, double A, double n, double E)
        {
            double x1 = 0, Fx = 0;
            do
            {
                 x1 = x * (1 - ((1 - (A / Math.Pow(x, n))) / n));
                Fx = Math.Abs(x1 - x);
                x = x1;
            } 
            while (Fx >= E);
           
            return x1;
        }
    }
}
