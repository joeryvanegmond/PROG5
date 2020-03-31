using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // loop
            while (true) {

                // array
                var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy" };

                Console.WriteLine("What's your birth date? ");
                string input = Console.ReadLine();
                DateTime scheduleDate;

                // wat doet dit precies en hoe heet het?
                bool validDate = DateTime.TryParseExact(
                    input,
                    dateFormats,
                    DateTimeFormatInfo.InvariantInfo,
                    DateTimeStyles.None,
                    out scheduleDate);

                if (validDate)
                {
                    // calculate age
                    DateTime birthdate = Convert.ToDateTime(scheduleDate);
                    int age = DateTime.Today.Year - birthdate.Year;

                    //write age
                    Console.WriteLine("You are " + age + " years old \n");
                }
                else
                {
                    Console.WriteLine("invalid input, try again. \n");
                }

            }

        }
    }
}
