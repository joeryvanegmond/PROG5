using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace NinjaManager.ViewModel
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddNinjaVM>();
            SimpleIoc.Default.Register<EditNinjaVM>();
            SimpleIoc.Default.Register<ShopVM>();
            SimpleIoc.Default.Unregister<InventoryVM>();
            SimpleIoc.Default.Register<InventoryVM>();
            SimpleIoc.Default.Register<AddEquipmentVM>();
            SimpleIoc.Default.Unregister<EditEquipmentVM>();
            SimpleIoc.Default.Register<EditEquipmentVM>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AddNinjaVM AddNinja
        {
            get
            {
                 return ServiceLocator.Current.GetInstance<AddNinjaVM>();
            }

        }

        public EditNinjaVM EditNinja
        {
            get
            {
                return new EditNinjaVM(Main);
            }
        }

        public InventoryVM NinjaInventory
        {
            get
            {
                ServiceLocator.Current.GetInstance<InventoryVM>().ReInitialize();
                return ServiceLocator.Current.GetInstance<InventoryVM>();
            }
        }

        public ShopVM Shop
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShopVM>();
            }
        }

        public AddEquipmentVM AddEquipment
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddEquipmentVM>();
            }
        }

        public EditEquipmentVM EditEquipment
        {
            get
            {
                return new EditEquipmentVM(Main, Shop);
            }
        }

    }
}
