using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NinjaManager.Domain;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class ShopVM : ViewModelBase
    {
        private MainViewModel _main;
        public InventoryVM _inventory;
        private ObservableCollection<Equipment> _equipmentCollection;
        public ObservableCollection<Equipment> EquipmentCollection 
        {
            get 
            {
                return _equipmentCollection;
            }

            set 
            {
                _equipmentCollection = value;
                RaisePropertyChanged("EquipmentCollection");
            } 
        }

        private Equipment _selectedEquipment;
        public Equipment SelectedEquipment
        {
            get { return _selectedEquipment; }
            set
            {
                _selectedEquipment = value;
                RaisePropertyChanged("SelectedEquipment");
            }
        }

        private string _equipmentCatagory;
        public string EquipmentCatagory
        {
            get
            {
                return _equipmentCatagory;
            }

            set
            {
                _equipmentCatagory = value;
                RaisePropertyChanged("EquipmentCatagory");
            }
        }

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

        public ObservableCollection<string> CatagoryNames;

        public ShopVM(MainViewModel main, InventoryVM inventory)
        {
            this._main = main;
            this._inventory = inventory;

            CatagoryNames = new ObservableCollection<string>();
            


            using (var context = new NinjaManagerEntities())
            {
                EquipmentCollection = new ObservableCollection<Equipment>(context.Equipment.ToList());

                var names = context.Category.ToList();

                foreach (var name in names)
                {
                    CatagoryNames.Add(name.Category1);
                }
            }

            BuyCommand = new RelayCommand<OpenShopWindow>(BuyEquipment);
            SellEquipmentCommand = new RelayCommand<OpenShopWindow>(SellEquipment);

            EquipmentCatagory = CatagoryNames[0];

            ShowAddEquipmentCommand = new RelayCommand(() =>
            {
                new AddEquipmentWindow().Show();
            });

            ShowEditEquipmentCommand = new RelayCommand(() =>
            {
                new EditEquipmentWindow().Show();
            });

            DeleteEquipmentCommand = new RelayCommand<OpenShopWindow>(DeleteEquipment);
        }

        private void DeleteEquipment(OpenShopWindow shopWindow)
        {
            SellEquipment(shopWindow);
            using (var context = new NinjaManagerEntities())
            {
                context.Equipment.Remove(context.Equipment.Where(n => n.Id.Equals(_selectedEquipment.Id)).FirstOrDefault());
                EquipmentCollection.Remove(SelectedEquipment);
                context.SaveChanges();
            }
        }

        public ICommand ShowAddEquipmentCommand { get; set; }
        public ICommand ShowEditEquipmentCommand { get; set; }
        public ICommand DeleteEquipmentCommand { get; set; }
        public ICommand BuyCommand { get; set; }
        public ICommand SellEquipmentCommand { get; set; }

        private void SellEquipment(OpenShopWindow shopWindow)
        {
            if (_main.SelectedNinja == null)
            {
                shopWindow.Close();
                return;
            }

            if (!_inventory.EquipmentCollection.Any(e => e.Id == SelectedEquipment.Id))
            {
                ErrorMessage = "Je kunt dit niet verkopen";
                return;
            }

            using (var context = new NinjaManagerEntities())
            {
                var ninja = context.Ninja.Find(_main.SelectedNinja.Id);
                var equipment = context.Equipment.Find(SelectedEquipment.Id);
                ninja.Equipment.Remove(equipment);
                equipment.Ninja.Remove(ninja);
                context.Ninja.Find(_main.SelectedNinja.Id).Gold += SelectedEquipment.Gold;
                context.SaveChanges();

                _inventory.EquipmentValue = _inventory.EquipmentValue - SelectedEquipment.Gold;
                _inventory.StrengthValue -= SelectedEquipment.Strength;
                _inventory.IntelligenceValue -= SelectedEquipment.Intelligence;
                _inventory.AgilityValue -= SelectedEquipment.Agility;
                _inventory.EquipmentCollection.Remove(SelectedEquipment);
                _inventory.Gold = _inventory.Gold + SelectedEquipment.Gold;
                
                ErrorMessage = "";
            }
        }

        private void BuyEquipment(OpenShopWindow shopWindow)
        {
            if (_main.SelectedNinja == null)
            {
                shopWindow.Close();
                return;
            }

            if (_inventory.EquipmentCollection.Any(e => e.Category == SelectedEquipment.Category))
            {
                ErrorMessage = "Je hebt al een item van deze categorie";
                return;
            }

            if (_inventory.Gold >= SelectedEquipment.Gold)
            {
                using (var context = new NinjaManagerEntities())
                {
                    var ninja = context.Ninja.Find(_main.SelectedNinja.Id);
                    if (_inventory.EquipmentCollection.Any(e => e.Id == SelectedEquipment.Id))
                    {
                        ErrorMessage = "Je hebt dit item al in bezit";
                        return;
                    }
                    var equipment = context.Equipment.Find(SelectedEquipment.Id);
                    ninja.Equipment.Add(equipment);
                    equipment.Ninja.Add(ninja);
                    context.Ninja.Find(_main.SelectedNinja.Id).Gold -= SelectedEquipment.Gold; // update amount from ninja in database
                    context.SaveChanges();

                    _inventory.EquipmentCollection.Add(SelectedEquipment); // add equipment to inventory
                    _inventory.EquipmentValue += SelectedEquipment.Gold; // update total equipment worth in inventory
                    _inventory.StrengthValue += SelectedEquipment.Strength;
                    _inventory.IntelligenceValue += SelectedEquipment.Intelligence;
                    _inventory.AgilityValue += SelectedEquipment.Agility;
                    _inventory.Gold = _inventory.Gold - SelectedEquipment.Gold; // update amount from ninja in inventory
                }
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = "Je hebt niet genoeg gold";
            }
            
        }

    




    }
}
