using System;

namespace KorenNuton
{
    class Raschet
    {
      internal static void вводДанных(out double A, out double E, out int n)
        {
            try
            {
                Console.WriteLine("Введите степень корня n, значение подкоренного выражения A и точность E");
                string[] аргументы = Console.ReadLine().Replace('.', ',').Split(' ');
                n = Convert.ToInt32(аргументы[0]);
                A = double.Parse(аргументы[1]);
                E = double.Parse(аргументы[2]);
                if (A < 0 && (n % 2) == 0)
                {
                    Console.WriteLine("неверные данныe. Подкоренное выражение или степень < 0");
                    вводДанных(out A, out E, out n);
                }
                if (n < 0)
                {
                    Console.WriteLine("неверные данныe. Подкоренное выражение или степень < 0");
                    вводДанных(out A, out E, out n);
                }
                if (E < 0)
                {
                    Console.WriteLine("неверные данныe. E < 0");
                    вводДанных(out A, out E, out n);
                }

            }
            catch
            {
                Console.WriteLine("неверные данные");
                вводДанных(out A, out E, out n);
            }
        }

       internal static double начальноеПриближение(double A, int n)
        {
            double x0 = A * 0.3 / n;
            return x0;
        }

        internal static double методНьютона(double x, double A, double n, double E)
        {
            double x1 = 0, Fx = 0;
            if (x == 0)
            {
                x1 = 0;
            }

            else
            {
                do
                {
                    x1 = x * (1 - ((1 - (A / Math.Pow(x, n))) / n));
                    Fx = Math.Abs(x1 - x);
                    x = x1;
                }
                while (Fx >= E);
            }
            
            return x1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double A, E, MP;
            int n;
            Raschet.вводДанных(out A, out E, out n);  
            double x = Raschet.начальноеПриближение(A, n);
            double X = Raschet.методНьютона(x, A, n, E);
            Console.WriteLine("Ваш корень равен " + X);
            if (A < 0)
            {
                A *= -1;
                MP = Math.Pow(A, 1.0 / n);
                MP *= -1;
            }
           else MP = Math.Pow(A, 1.0 / n);
            Console.WriteLine("Через Math.Pow " + MP);
            Console.ReadLine();
        }

        
    }
}
