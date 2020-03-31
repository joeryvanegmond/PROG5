
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NinjaManager.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    class EditNinjaVM : ViewModelBase
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

        public EditNinjaVM(MainViewModel main)
        {
            this._main = main;
            NinjaName = main.SelectedNinja.Name;
            NinjaGold = main.SelectedNinja.Gold;

            SaveNinjaCommand = new RelayCommand<EditNinjaWindow>(SaveNinja);
        }

        public ICommand SaveNinjaCommand { get; set; }

        private void SaveNinja(EditNinjaWindow editNinjaWindow)
        {
            using (var context = new NinjaManagerEntities())
            {
                Ninja Ninja = _main.SelectedNinja;
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

                context.Ninja.Attach(Ninja);
                context.Entry(Ninja).State = EntityState.Modified;
                context.SaveChanges();

                _main.Ninjas = new ObservableCollection<Ninja>(context.Ninja.ToList());
            }

            editNinjaWindow.Close();
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
