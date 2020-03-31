using System;
using System.Windows.Input;

namespace Prog5.HW
{
    internal class SetMinAmount : ICommand
    {
        private PersonVM personVM;

        public SetMinAmount(PersonVM personVM)
        {
            this.personVM = personVM;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (personVM == null)
            {
                return false;
            }
            else
            {
                return personVM.Amount >= 10;
            }
        }

        void ICommand.Execute(object parameter)
        {
            personVM.Amount -= 10;
        }
    }
}