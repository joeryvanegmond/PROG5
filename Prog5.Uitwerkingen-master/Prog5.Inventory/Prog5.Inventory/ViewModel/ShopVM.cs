using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prog5.Inventory.ViewModel
{
    public class ShopVM : ViewModelBase
    {
        private MainViewModel main;

        public ObservableCollection<Gear> Items { get; set; }

        public RelayCommand BuyItemCommand { get; set; }

        private Gear _selected;
        public Gear Selected
        {
            get { return _selected;  }
            set {
                _selected = value;
                this.BuyItemCommand.RaiseCanExecuteChanged();
            }
        }

        public ShopVM(MainViewModel main)
        {
            this.main = main;
            this.Items = new ObservableCollection<Gear>();
            this.InsertDummyItems();
            this.BuyItemCommand = new RelayCommand(BuyItem, CanBuyItem);
        }

        private bool CanBuyItem()
        {
            return this.Selected != null && main.Inventory.Count() < 6;
        }

        private void BuyItem()
        {
            this.main.AddItem(Selected);
            this.BuyItemCommand.RaiseCanExecuteChanged();
        }

        private void InsertDummyItems()
        {
            this.Items.Add(new Gear() { Name = "Boots", Price = 100 });
            this.Items.Add(new Gear() { Name = "Pants", Price = 200 });
            this.Items.Add(new Gear() { Name = "Belt", Price = 60 });
            this.Items.Add(new Gear() { Name = "Shirt", Price = 120 });
            this.Items.Add(new Gear() { Name = "Shoulders", Price = 320 });
            this.Items.Add(new Gear() { Name = "Helmet", Price = 210 });
            this.Items.Add(new Gear() { Name = "Trinket", Price = 30 });
        }
    }
}
