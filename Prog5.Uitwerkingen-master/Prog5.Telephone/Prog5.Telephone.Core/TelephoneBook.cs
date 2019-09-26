using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq; //Deze namespace is heel belangerijk

namespace Telefoonboek.uitwerking
{
    public class TelephoneBook : ITelephoneBook
    {
        public IList<IPerson> People { get; set; }

        /// <summary>
        /// Lege constructor
        /// </summary>
        public TelephoneBook()
        {
            People = new List<IPerson>();
        }

        /// <summary>
        /// Constructor op basis van lijst
        /// </summary>
        public TelephoneBook(List<IPerson> people)
        {
            this.People = people;
        }

        public int Count
        {
            get { return this.People.Count; }
        }

        public List<IPerson> SortByLastName()
        {
            //return People.OrderBy(m => m.LastName).ToList();

            var result = from p in People
                         orderby p.LastName
                         select p;

            return result.ToList();
        }

        public List<IPerson> FirstNameStartWith(char firstChar)
        {
            //return People
            //    .Where(p => p.FirstName[0] == firstChar)
            //    .OrderBy(m => m.LastName).ToList();

            var result = from p in People
                          where p.FirstName[0] == firstChar
                          orderby p.LastName
                          select p;

            return result.ToList();

        }

        public List<String> LastNameLongerThen(int length)
        {
            //return People
            //     .Where(p => p.LastName.Length > length)
            //     .OrderBy(m => m.LastName).ToList();

            var result = from p in People
                         where p.LastName.Length > length
                         orderby p.LastName
                         select p.LastName;

            return result.ToList();

        }

        public List<IPerson> SortByLastNameLength()
        {
            //return People.OrderBy(p => p.LastName.Length).ToList();

            var result = from p in People
                         orderby p.LastName.Length
                         select p;

            return result.ToList();
        }
    }
}
