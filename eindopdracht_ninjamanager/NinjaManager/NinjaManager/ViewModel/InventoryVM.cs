using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class InventoryVM : ViewModelBase
    {
        private MainViewModel _main;
        private Ninja _selectedNinja;
        public Ninja SelectedNinja
        {
            get
            {
                return _selectedNinja;
            }
            set
            {
                _selectedNinja = value;
                RaisePropertyChanged("SelectedNinja");
            }
        }
        private int _gold;
        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
                RaisePropertyChanged("Gold");
            }
        }

        private int _equipmenValue;
        public int EquipmentValue
        {
            get
            {
                return _equipmenValue;
            }
            set
            {
                _equipmenValue = value;
                RaisePropertyChanged("EquipmentValue");
            }
        }

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
                EquipmentValue = 0;
                StrengthValue = 0;
                AgilityValue = 0;
                IntelligenceValue = 0;
                foreach (var item in EquipmentCollection)
                {
                    EquipmentValue += item.Gold;
                    StrengthValue += item.Strength;
                    AgilityValue += item.Agility;
                    IntelligenceValue += item.Intelligence;
                }
                RaisePropertyChanged("EquipmentCollection");
            }
        }

        private int _strengthValue;
        public int StrengthValue
        {
            get
            {
                return _strengthValue;
            }
            set
            {
                _strengthValue = value;
                RaisePropertyChanged("StrengthValue");
            }
        }

        private int _agilityValue;
        public int AgilityValue
        {
            get
            {
                return _agilityValue;
            }
            set
            {
                _agilityValue = value;
                RaisePropertyChanged("AgilityValue");
            }
        }

        private int _intelligenceValue;
        public int IntelligenceValue
        {
            get
            {
                return _intelligenceValue;
            }
            set
            {
                _intelligenceValue = value;
                RaisePropertyChanged("IntelligenceValue");
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

        public InventoryVM(MainViewModel main)
        {
            this._main = main;
            _selectedNinja = main.SelectedNinja;
            Gold = _main.SelectedNinja.Gold;

            using (var context = new NinjaManagerEntities())
            {
                var inventory = context.Ninja.Find(_selectedNinja.Id).Equipment.ToList();
                EquipmentCollection = new ObservableCollection<Equipment>(inventory);
            }

            OpenShopCommand = new RelayCommand(() =>
            {
                new OpenShopWindow().Show();
            }
           );

            EmptyInventoryCommand = new RelayCommand<OpenInventoryWindow>(EmptyInventory);
        }


        public ICommand OpenShopCommand { get; set; }
        public ICommand EmptyInventoryCommand { get; set; }
        private void EmptyInventory(OpenInventoryWindow inventoryWindow)
        {

            if (_main.SelectedNinja == null)
            {
                inventoryWindow.Close();
                return;
            }

            if (EquipmentCollection.Count == 0)
            {
                ErrorMessage = "Je inventory is leeg";
                return;
            }
            using (var context = new NinjaManagerEntities())
            {
                foreach (var item in EquipmentCollection)
                {
                    var ninja = context.Ninja.Find(_main.SelectedNinja.Id);
                    var equipment = context.Equipment.Find(item.Id);
                    ninja.Equipment.Remove(equipment);
                    equipment.Ninja.Remove(ninja);
                    context.Ninja.Find(_main.SelectedNinja.Id).Gold += item.Gold;

                    EquipmentValue = EquipmentValue - item.Gold;
                    StrengthValue = StrengthValue - item.Strength;
                    AgilityValue = AgilityValue - item.Agility;
                    IntelligenceValue = IntelligenceValue - item.Intelligence;

                    Gold = Gold + item.Gold;
                }
                    EquipmentCollection.Clear();

                context.SaveChanges();
                ErrorMessage = "";
            }
        }

        private void CheckIfSelectedNinjaIsNUll(OpenInventoryWindow inventoryWindow)
        {
            if (_main.SelectedNinja == null)
            {
                inventoryWindow.Close();
                return;
            }
            
        }

        public void ReInitialize()
        {
            _selectedNinja = _main.SelectedNinja;
            Gold = _main.SelectedNinja.Gold;

            using (var context = new NinjaManagerEntities())
            {
                var inventory = context.Ninja.Find(_selectedNinja.Id).Equipment.ToList();
                EquipmentCollection = new ObservableCollection<Equipment>(inventory);
            }
        }
    }
}
