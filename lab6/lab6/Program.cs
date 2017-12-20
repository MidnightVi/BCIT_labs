using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab6_1
{
    class Program
    {
        public delegate float roots(float p1, int p2);

        static roots discr=(float p1, int p2) =>
        {
            return p1*p1-4*p2;

        };
        static Func<float,int,float> discr1 = (float p1, int p2) =>
        {
            return p1 * p1 - 4 * p2;

        };
        static float Findroot(float p1, int p2)
        {
            return p1 / (2 * p2);
        }

    

        static void equation(int a, int b, int c, roots discr, roots root)
        {
            if (discr(b, a * c) > 0)
            {
                Console.WriteLine("Root1 1: " + root(-b + discr(b, a * c), a));
                Console.WriteLine("Root1 2: " + root(-b - discr(b, a * c), a));
            }
            else
                if (discr(b, a * c) == 0)
                    Console.WriteLine("Root1 : " + root(-b, a));

            else
                if (discr(b, a * c) < 0)
                Console.WriteLine("No roots");
        }

        static void equation1(int a, int b, int c, Func<float,int,float> discr, Func<float, int, float> root)
        {
            if (discr(b, a * c) > 0)
            {
                Console.WriteLine("Root1 1: " + root(-b + discr(b, a * c), a));
                Console.WriteLine("Root1 2: " + root(-b - discr(b, a * c), a));
            }
            else
                if (discr(b, a * c) == 0)
                Console.WriteLine("Root1 : " + root(-b, a));

            else
                if (discr(b, a * c) < 0)
                Console.WriteLine("No roots");
        }

        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Please put in a, b, c");
            Console.Write("a: ");
            a = Int32.Parse(Console.ReadLine());
            Console.Write("b: ");
            b = Int32.Parse(Console.ReadLine());
            Console.Write("c: ");
            c = Int32.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Finding roots using delegates and lambda expression:");
            equation(a, b, c, discr, Findroot);

            Console.WriteLine();
            Console.WriteLine("Finding roots using Func:");
            equation1(a, b, c, discr1, Findroot);

            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.Read();
        }
    }
}
