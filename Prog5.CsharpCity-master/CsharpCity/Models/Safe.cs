using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpCity.Models
{
    public class Safe
    {
        private int _random;

        public int RandomIndex { get { return this._random; } }

        private double _money;

        public double Money { get { return this._money; } }

        public bool IsOpen { get; private set; }

        public Safe(int random, int money)
        {
            this._random = random;
            this._money = money;
            this.IsOpen = false;
        }

        public void OpenSafe()
        {
            this.IsOpen = true;
        }


    }
}
