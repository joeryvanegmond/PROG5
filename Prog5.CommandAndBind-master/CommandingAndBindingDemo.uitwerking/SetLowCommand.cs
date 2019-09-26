using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandingAndBindingDemo
{
    class SetLowCommand : ICommand
    {
        private TemperatureVM viewmodel;

        public SetLowCommand(TemperatureVM viewmodel)
        {
            this.viewmodel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            if(viewmodel == null)
            {
                return false;
            }
            else
            {
                return viewmodel.Temperature > 10;
            }
        }

        public void Execute(object parameter)
        {
            viewmodel.Temperature = 0;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
