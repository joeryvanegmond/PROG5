using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;

namespace CsharpCity.Models
{
    /// <summary>
    /// DEZE KLASSE IS SUPER HARD BEVEILIGD MET ANTI HACKER SOFTWARE
    /// ALS JE EEN REGEL CODE AANPAST ONPLOFT JE COMPUTER!!!!!!!!!!!
    /// </summary>
    public class Vault
    {
        private bool _isOpen = false;

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
        }

        public string ThisPropertyDoesNothing
        {
            set
            {
                if (value == "ReallyNothing")
                {
                    _isOpen = true;
                }
                    
            }
        }
    }
}
