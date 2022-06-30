using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Basics
{
    class Program 
    {

        static void Main(string[] args) 
        {
            bool shouldRun = true;
            while (shouldRun) 
            {
                RunProgram();
                Console.WriteLine("Another equation? y/n");
                string answer = Console.ReadLine();

                while (answer != "y" && answer != "n") 
                {
                    Console.WriteLine("type 'y' or 'n'");
                    answer = Console.ReadLine();
                }

                if (answer == "n") shouldRun = false;
            }
        }

        static void RunProgram() 
        {
            Console.WriteLine("Type in a, b and c for your quadratic equation");
            
            Console.WriteLine("a:");
            string a = Console.ReadLine();

            while (!IsValidK(a)) 
            {
                Console.WriteLine("a:");
                a = Console.ReadLine();
            }

            Console.WriteLine("b:");
            string b = Console.ReadLine();

            while (!IsValidK(b)) 
            {
                Console.WriteLine("b:");
                b = Console.ReadLine();
            }

            Console.WriteLine("c:");
            string c = Console.ReadLine();

            while (!IsValidK(c)) 
            {
                Console.WriteLine("b:");
                c = Console.ReadLine();
            }

            double ak = Convert.ToDouble(a);
            double bk = Convert.ToDouble(b);
            double ck = Convert.ToDouble(c);

            List<double> sqRoots = SolveQEquation(ak, bk, ck);

            if (sqRoots.Count == 0) 
            {
                Console.WriteLine("No roots");
            }
            else 
            {
                Console.WriteLine("The roots are:");
                foreach (double r in sqRoots) {
                    Console.WriteLine(r);
                }
            }
        }

        static bool IsValidK(string k) 
        {
            try
            {
                Convert.ToDouble(k);
                return true;
            }
            catch
            {
                Console.WriteLine("Try a valid number");
                return false;
            }
        }

        static List<double> SolveQEquation(double a, double b, double c) 
        {
            if (a == 0) throw new ArgumentException("Not a Quadratic Equation", nameof(a));

            List<double> outResult = new List<double>();

            double d = b * b - 4 * a * c;

            if (d < 0) 
            {
                return outResult;
            }

            if (d == 0) 
            {
                outResult.Add((-b + Math.Sqrt(d)) / (2 * a));
                return outResult;
            }

            outResult.Add((-b + Math.Sqrt(d)) / (2 * a));
            outResult.Add((-b - Math.Sqrt(d)) / (2 * a));

            return outResult;
        }
    }
}
