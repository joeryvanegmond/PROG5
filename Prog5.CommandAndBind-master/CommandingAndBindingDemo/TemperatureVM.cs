using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandingAndBindingDemo
{
    public class TemperatureVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Privates, getters en setters for temparture
        /// </summary>
        private double _temperature;
        public double Temperature 
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                RaisePropertyChanged("Temperature");
            }
        }

        public ICommand SetLowCommand { get; set; }

        /// <summary>
        /// Constructor!
        /// </summary>
        public TemperatureVM()
        {
            this._temperature = 22;
            SetLowCommand = new SetLowCommand(this);
        }


        #region INotifyPropertyChanged Members


            void RaisePropertyChanged(string prop)
            {
                if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
            }

            public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}
