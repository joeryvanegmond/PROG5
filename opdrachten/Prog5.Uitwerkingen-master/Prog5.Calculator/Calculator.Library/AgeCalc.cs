using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Library {
    public class AgeCalc : IAgeCalculator {

        //dubbel tap ftw

        public int CalculateAge(DateTime dateOfBirth) {
            TimeSpan diffrence = DateTime.Now.Subtract(dateOfBirth);
            int leeftijd = (int)(diffrence.TotalDays / 365.25);
            return leeftijd;
        }

        public bool ParseInput(string input, out DateTime result) {
            var isDate = DateTime.TryParse(input, out result);

            return (isDate && result.CompareTo(DateTime.Now) == -1);
        }
    }
}
