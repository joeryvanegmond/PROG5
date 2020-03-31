using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Prog5.HW
{
    class PersonVM : INotifyPropertyChanged
    {
        private String _Naam;
        private int _Amount;
        private DateTime _Date;
        private int _Age = 0;
        private String _Test;

        public ICommand SetNewDate { get; set; }

        public ICommand SetMinAmount { get; set; }

        // constructor
        public PersonVM()
        {
            this._Naam = "Joery";
            this._Amount = 100;
            this._Age = 0;

            //Maak een nieuw Command aan
            SetNewDate = new SetPlusAmount(this);
            SetMinAmount = new SetMinAmount(this);
        }
        public int Amount
        {
            get { return _Amount; }

            set
            {
                _Amount = value;
                RaisePropertyChanged("Amount");
            }
        }

        public String Naam
        {
            get { return _Naam; }
            set
            {
                _Naam = value;
                RaisePropertyChanged("Naam");
            }
        }

        public DateTime Date {
            get { return _Date; }
            set
            {
                _Date = value;
                RaisePropertyChanged("Date");
            }
        }

        public int Age
        {
            get { return _Age; }
            set
            {
                _Age = value;
                RaisePropertyChanged("Age");
            }
        }

        public String Test {
            get { return _Test; }
            set {
                _Test = value;
                RaisePropertyChanged("Test");
            }
        }

        #region INotifyPropertyChanged Members

        void RaisePropertyChanged(String prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}
