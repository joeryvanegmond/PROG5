using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephonebook
{
    class Person
    {

        public Person(String firstName, String lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int TelephoneNumber { get; set; }
        public String FullName {

            get {
                return FirstName + " " + LastName;
            }
        }



       
       

    }
}
