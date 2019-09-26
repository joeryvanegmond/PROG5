using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using Prog5.Inventory.View;

namespace Prog5.Inventory.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Gear> Inventory { get; set; }

        public ICommand OpenShopCommand { get; set; }

        public MainViewModel()
        {
            OpenShopCommand = new RelayCommand(OpenShop);
            this.Inventory = new ObservableCollection<Gear>();
        }

        internal void AddItem(Gear item)
        {
            this.Inventory.Add(item);
        }

        private void OpenShop()
        {
            var shopWindow = new ShopWindow();
            shopWindow.Visibility = System.Windows.Visibility.Visible;
        }
    }
}