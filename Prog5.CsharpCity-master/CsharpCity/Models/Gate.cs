using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCity.Models
{
    public class Gate
    {
        public bool IsOpen  
        {
            get 
            {
                return this._sleutel != null;
            }
        }

        private Key _sleutel;

        public Key Sleutelgat
        {
            set
            {
                _sleutel = value;
            }
        }
    }
}
