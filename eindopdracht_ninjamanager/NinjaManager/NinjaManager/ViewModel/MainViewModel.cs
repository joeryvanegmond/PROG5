using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NinjaManager.Domain;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;


namespace NinjaManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Ninja _selectedNinja;
        private ObservableCollection<Ninja> _ninjas;
        public ObservableCollection<Ninja> Ninjas 
        {
            get 
            {
                return _ninjas;
            }

            set 
            {
                _ninjas = value;
                base.RaisePropertyChanged("Ninjas");
            }
        }

        public InventoryVM Inventory { get; set; }

        public ICommand ShowAddNinjaCommand { get; set; }
        public ICommand DeleteNinjaCommand { get; set; }
        public ICommand ShowEditNinjaCommand { get; set; }
        public ICommand ShowInventoryCommand { get; set; }

        public MainViewModel() 
        {
            //verbinden met de database
            using (var context  = new NinjaManagerEntities())
            {
                var ninjas = context.Ninja.ToList();
                Ninjas = new ObservableCollection<Ninja>(ninjas);
            }


            ShowAddNinjaCommand = new RelayCommand(() =>
            {
                new AddNinjaWindow().Show();
            });

            DeleteNinjaCommand = new RelayCommand(DeleteNinja);

            ShowEditNinjaCommand = new RelayCommand(() =>
            {
                new EditNinjaWindow().Show();
            }
           );

            ShowInventoryCommand = new RelayCommand(() =>
            {
                new OpenInventoryWindow().Show();
            }
           );


        }

        private void DeleteNinja()
        {
            using (var context = new NinjaManagerEntities())
            {
                context.Ninja.Remove(context.Ninja.Where(n => n.Id.Equals(_selectedNinja.Id)).FirstOrDefault());
                Ninjas.Remove(SelectedNinja);
                context.SaveChanges();
            }
        }

        public Ninja SelectedNinja
        {
            get { return _selectedNinja; }
            set
            {
                _selectedNinja = value;
                base.RaisePropertyChanged();
            }
        }


    }
}
