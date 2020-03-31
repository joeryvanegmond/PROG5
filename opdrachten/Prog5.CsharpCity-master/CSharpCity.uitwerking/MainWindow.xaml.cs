using CsharpCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CsharpCity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bank bank;

        public MainWindow()
        {
            InitializeComponent();

            this.bank = new Bank();
            bank.Guard = new Guard();
            bank.Gate = new Gate();
            bank.Vault = new Vault();
            bank.Lazors = new List<Lazor>(){
                new Lazor(),
                new Lazor(),
                new Lazor(),
                new Lazor(),
                new Lazor()
            };

            bank.SafeList = new List<Safe>();

            Random gen = new Random();
            for (int index = 0; index < 100; index++)
            {
                var r = gen.Next(0, 1000);
                bank.SafeList.Add(new Safe(r, index * 10));
            }

            Safe juwels = new Safe(500, 999999);
            bank.SafeList.Add(juwels);
            bank.SafeList.OrderBy(s => s.RandomIndex);

            Thief thief = new Thief();
            thief.bank = bank;

            //1. Do your thing thief
            thief.OpenGate();
            thief.OpenVault();
            thief.DodgeLazors();
            thief.FindAndOpenSafe();

            if (bank.Gate.IsOpen)
            {
                Storyboard sb = this.FindResource("OpenDoor") as Storyboard;
                sb.Completed += sb_Completed;
                sb.Begin();
                
            }

        }

        void sb_Completed(object sender, EventArgs e)
        {
            if (bank.Vault.IsOpen)
            {
                Storyboard openVault = this.FindResource("OpenVault") as Storyboard;
                openVault.Completed += openVault_Completed;
                openVault.Begin();
                
            }
        }

        void openVault_Completed(object sender, EventArgs e)
        {

            if (bank.Lazors.Any(l => l.Active))
            {
                Storyboard setAlarm = this.FindResource("SetAlarm") as Storyboard;
                setAlarm.Begin();
              
            }
            else
            {
                Storyboard disableLazors = this.FindResource("DisableLazors") as Storyboard;
                disableLazors.Completed += disableLazors_Completed;
                disableLazors.Begin();
            }
        }

        void disableLazors_Completed(object sender, EventArgs e)
        {
            if (bank.SafeList.Count(s => s.IsOpen) > 1)
            {
                Storyboard setAlarm = this.FindResource("SetAlarm") as Storyboard;
                setAlarm.Begin();
            }
            else if (bank.SafeList.Count(s => s.IsOpen) == 1)
            {
                Storyboard openSafe = this.FindResource("OpenSafe") as Storyboard;
                openSafe.Begin();
            }
        }
    }
}
