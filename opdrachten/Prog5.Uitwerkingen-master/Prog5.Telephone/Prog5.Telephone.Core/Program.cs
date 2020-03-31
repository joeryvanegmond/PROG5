using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefoonboek.uitwerking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPerson> people = new List<IPerson>(){
                new Person(){
                    FirstName = "Bea",
                    LastName = "Knol",
                    TelephoneNumber = "06321312",
                },
                new Person(){
                    FirstName = "Ad",
                    LastName = "Baantjer",
                    TelephoneNumber = "064342892",
                },
                new Person(){
                    FirstName = "Celine",
                    LastName = "van Stakkeren",
                    TelephoneNumber = "064823942",
                }
            };

            TelephoneBook book = new TelephoneBook(people);

            //1. Sorteren op achternaam
            Console.WriteLine("### Sorteren op achternaam ###");
            var result = book.SortByLastName();
            PrintList(result);
            Console.WriteLine("");

            //1. Firstname begint met 'a'
            Console.WriteLine("### Firstname begint met 'A' ###");
            result = book.FirstNameStartWith('A');
            PrintList(result);
            Console.WriteLine("");

            //3. Lastname langer dan 5
            Console.WriteLine("### Lastname langer dan 5 ###");
            result = book.LastNameLongerThen(5);
            PrintList(result);
            Console.WriteLine("");

            //4. Sorteren op achternaam lengte
            Console.WriteLine("### Sorteren op achternaam lengte ###");
            result = book.SortByLastNameLength();
            PrintList(result);
            Console.WriteLine("");

            Console.ReadLine();

        }

        public static void PrintList(List<IPerson> people){
            for(int index = 0; index < people.Count; index++)
            {
                IPerson person = people[index];
                Console.WriteLine(index + ". " + person.FirstName + " " + person.LastName + " - " + person.TelephoneNumber);
            }
        }
    }
}
