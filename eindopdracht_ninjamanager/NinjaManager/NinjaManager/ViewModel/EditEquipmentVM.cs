using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class EditEquipmentVM : ViewModelBase
    {
        private MainViewModel _main;
        private ShopVM _shop;

        public string EquipmentName { get; set; }
        public int EquipmentGold { get; set; }
        public string EquipmentCatagory { get; set; }
        public int EquipmentStrength { get; set; }
        public int EquipmentAgillity { get; set; }
        public int EquipmentIntelligence { get; set; }
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
        public ObservableCollection<string> CatagoryNames { get; set; }


        public EditEquipmentVM(MainViewModel main, ShopVM shop)
        {
            this._main = main;
            this._shop = shop;

            EquipmentCatagory = shop.SelectedEquipment.Category;
            CatagoryNames = new ObservableCollection<string>(shop.CatagoryNames);
                

            SaveEquipmentCommand = new RelayCommand<EditEquipmentWindow>(SaveEquipment);

            EquipmentName = shop.SelectedEquipment.Name;
            EquipmentGold = shop.SelectedEquipment.Gold;
            EquipmentCatagory = shop.SelectedEquipment.Category;
            EquipmentStrength = shop.SelectedEquipment.Strength;
            EquipmentAgillity = shop.SelectedEquipment.Agility;
            EquipmentIntelligence = shop.SelectedEquipment.Intelligence;


        }

        public ICommand SaveEquipmentCommand { get; set; }

        private void SaveEquipment(EditEquipmentWindow editEquipmentWindow) 
        {

            using (var context = new NinjaManagerEntities())
            {
                Equipment equipment = new Equipment();
                if (Check(EquipmentName))
                {
                    ErrorMessage = "Geef een naam";
                    return;
                }
                else if (EquipmentGold <= 0 || EquipmentStrength <= 0 || EquipmentAgillity <= 0 || EquipmentIntelligence <= 0)
                {
                    ErrorMessage = "Vul alle velden in";
                    return;
                }

                var temp = context.Equipment.Find(_shop.SelectedEquipment.Id);
                temp.Name = EquipmentName;
                temp.Gold = EquipmentGold;
                temp.Category = EquipmentCatagory;
                temp.Strength = EquipmentStrength;
                temp.Agility = EquipmentAgillity;
                temp.Intelligence = EquipmentIntelligence;

                context.SaveChanges();

                _shop.EquipmentCollection = new ObservableCollection<Equipment>(context.Equipment.ToList());
                _shop._inventory.EquipmentCollection = new ObservableCollection<Equipment>(context.Ninja.Find(_main.SelectedNinja.Id).Equipment.ToList());
            }
            editEquipmentWindow.Close();
        }

        public bool Check(string str)
        {
            return (String.IsNullOrEmpty(str) ||
                  str.Trim().Length == 0) ? true : false;
        }
    }
}