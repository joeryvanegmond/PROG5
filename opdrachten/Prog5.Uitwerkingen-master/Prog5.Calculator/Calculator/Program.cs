using Calculator.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welkom, wanneer ben je gebore?");
            string input = Console.ReadLine();
            DateTime result;
            IAgeCalculator calcy = new AgeCalc();
            while(!calcy.ParseInput(input, out result))
            {
                Console.WriteLine("foute input, probeer het opnieuw!");
                input = Console.ReadLine();
            }
            int leeftijd = calcy.CalculateAge(result);
            Console.WriteLine(leeftijd);
            Console.ReadLine();
        }
    }
}
