using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            TelephoneBook telephoneBook = new TelephoneBook();
            telephoneBook.printSortedLastName();
            Console.WriteLine();
            telephoneBook.printStartsWith();
            Console.WriteLine();
            telephoneBook.printLongerThan();
            Console.WriteLine();
            telephoneBook.printSortOnLength();
            Console.WriteLine();
            telephoneBook.printAmount();
            Console.ReadKey();
        }
    }
}
