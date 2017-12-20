using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
   class Program
    {
        static void Main(string[] args)
        {
            double a = ReadDouble("Введите коэффициент А: ");
            double b = ReadDouble("Введите коэффициент B: ");
            double c = ReadDouble("Введите коэффициент C: ");
            double D = b * b - 4 * a * c;
            Console.WriteLine("D= " + D);
            if (D == 0)
            {
                double k1 = (-b) / (2 * a);
                Console.WriteLine("Корень =" + k1);
            }
            else if (D < 0)
            {
                Console.WriteLine("Корней нет");
            }
            else
            {
                double k2 = ((-b) - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("Корень 1 = " + k2);
                double k3 = ((-b) + Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("Корень 2 = " + k3);
            }
            

        }

        static double ReadDouble(string message)
        {
            string resultString;
            double resultDouble;
            bool flag;

            do
            {
                Console.Write(message);
                resultString = Console.ReadLine();
                flag = double.TryParse(resultString, out resultDouble);
                if (!flag)
                {
                    Console.WriteLine("Необходимо ввести вещественное число");
                }
            }
            while (!flag);

            return resultDouble;
        }
    }
}

