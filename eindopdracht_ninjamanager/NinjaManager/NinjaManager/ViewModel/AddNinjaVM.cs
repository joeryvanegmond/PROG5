using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    class AddNinjaVM : ViewModelBase
    {
        private MainViewModel _main;

        public string NinjaName { get; set; }
        public int NinjaGold { get; set; }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

        public AddNinjaVM(MainViewModel main)
        {
            this._main = main;

            SaveNinjaCommand = new RelayCommand<AddNinjaWindow>(SaveNinja);
        }

        public ICommand SaveNinjaCommand { get; set; }

        private void SaveNinja(AddNinjaWindow addNinjaWindow)
        {
            using (var context = new NinjaManagerEntities())
            {
                Ninja Ninja = new Ninja();

                
                if (Check(NinjaName))
                {
                    ErrorMessage = "Geef je ninja een naam";
                    return;
                }
                else if (NinjaGold <= 0)
                {
                    ErrorMessage = "Gun je ninja wat goud";
                    return;
                }

                Ninja.Name = NinjaName;
                Ninja.Gold = NinjaGold;

                context.Ninja.Add(Ninja);
                context.SaveChanges();
                _main.Ninjas.Add(Ninja);
            }
            addNinjaWindow.Close();
            NinjaName = null;
            NinjaGold = 0;
            ErrorMessage = "";
        }

        public bool Check(string str)
        {
            return (String.IsNullOrEmpty(str) ||
                  str.Trim().Length == 0) ? true : false;
        }
    }
}
