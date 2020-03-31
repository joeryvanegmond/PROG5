using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephonebook
{
    class TelephoneBook
    {
        private List<Person> telephoneBook;

        public TelephoneBook() {
            telephoneBook = new List<Person>();
            //for (int i = 0; i < 10; i++) {
            //    telephoneBook.Add(new Person("firstname" + i, "lastname" + i));
            //}

            telephoneBook.Add(new Person("Joery", "van Egmond"));
            telephoneBook.Add(new Person("Tjeu", "Foolen"));
            telephoneBook.Add(new Person("Henry", "Baudett"));
            telephoneBook.Add(new Person("Bo", "van Ees"));
            telephoneBook.Add(new Person("Kees", "Speculaas"));
            telephoneBook.Add(new Person("Neppe", "van der slacht"));
            telephoneBook.Add(new Person("Jacer", "laptoppen"));
            telephoneBook.Add(new Person("Apple", "Macbook"));
            telephoneBook.Add(new Person("Bob", "van der Putten"));
            telephoneBook.Add(new Person("Ger", "Saris"));
        }

        public int AmountOfAdresses
        {
            get
            {
                return telephoneBook.Count();
            }
        }


        //print methods
        public void printSortedLastName() {
            Console.WriteLine("**sorted on lastname");
            print(sortTelephoneBook());
        }

        public void printStartsWith() {
            Console.WriteLine("**Starts with J");
            print(searchInTelephoneBook("J"));
        }

        public void printLongerThan() {
            Console.WriteLine("**Lastname longer than 9");
            print(lastNameLongerThan(9));
        }

        public void printSortOnLength() {
            Console.WriteLine("**Sort on length lastname");
            print(sortOnLength());
        }

        public void print(List<Person> list) {
           list.ForEach(x => Console.WriteLine(x.FullName));
        }

        public void printAmount() {
            Console.WriteLine("**Amount of adresses");
            Console.WriteLine(AmountOfAdresses);
        }


        // methods
        public List<Person> sortTelephoneBook() {
           return telephoneBook.OrderBy(t => t.LastName).ToList();
        }

        public List<Person> searchInTelephoneBook(String letter) {
           return telephoneBook.Where(t => t.FirstName.StartsWith(letter)).OrderBy(t => t.LastName).ToList();
        }

        public List<Person> lastNameLongerThan(int input) {
            return telephoneBook.Where(t => t.LastName.Length > input).ToList();
        }

        public List<Person> sortOnLength() {
            return telephoneBook.OrderBy(t => t.LastName.Length).ToList();
        }

    }
}
