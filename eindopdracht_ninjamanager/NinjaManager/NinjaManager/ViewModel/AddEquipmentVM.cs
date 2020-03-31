using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    class AddEquipmentVM : ViewModelBase
    {
        private ShopVM _shop;

        public string EquipmentName { get; set; }
        public int EquipmentGold { get; set; }
        public int EquipmentStrength { get; set; }
        public int EquipmentAgillity { get; set; }
        public int EquipmentIntelligence { get; set; }
        public string EquipmentCatagory { get; set; }
        public ObservableCollection<string> CatagoryNames { get; set; }
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

        public AddEquipmentVM(ShopVM shop)
        {
            this._shop = shop;

            CatagoryNames = shop.CatagoryNames;
            EquipmentCatagory = CatagoryNames[0];
            SaveEquipmentCommand = new RelayCommand<AddEquipmentWindow>(SaveEquipment);
        }

        public ICommand SaveEquipmentCommand { get; set; }


        private void SaveEquipment(AddEquipmentWindow addEquipmentWindow) 
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

                equipment.Name = EquipmentName;
                equipment.Gold = EquipmentGold;
                equipment.Category = EquipmentCatagory;
                equipment.Strength = EquipmentStrength;
                equipment.Agility = EquipmentAgillity;
                equipment.Intelligence = EquipmentIntelligence;

                context.Equipment.Add(equipment);
                context.SaveChanges();
                _shop.EquipmentCollection.Add(equipment);
            }
            addEquipmentWindow.Close();
            EquipmentName = null;
            EquipmentGold = 0;
            EquipmentStrength = 0;
            EquipmentAgillity = 0;
            EquipmentIntelligence = 0;
        }
        public bool Check(string str)
        {
            return (String.IsNullOrEmpty(str) ||
                  str.Trim().Length == 0) ? true : false;
        }
    }
}
