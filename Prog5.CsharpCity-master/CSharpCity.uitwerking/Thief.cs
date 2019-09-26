using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCity.Models
{
    public class Thief
    {
        public Bank bank { get; set; }

        //1. We moeten door de poort met tralies
        public void OpenGate()
        {
            Key key = bank.Guard.Key;
            bank.Gate.Sleutelgat = key;
        }

        //2. Verzin een manier om de Kluis open te maken
        public void OpenVault()
        {
            bank.Vault.ThisPropertyDoesNothing = "ReallyNothing";
        }

        //3. Verzin een manier om de lazors uit te schakelen
        public void DodgeLazors()
        {
            bank.Lazors.ForEach(l => l.Active = false);
        }

        //4. Er is 1 kluisje met daarin juwel die ultra veel waard zijn. Hoe kom je er achter welke?
        public void FindAndOpenSafe()
        {
            bank.SafeList.OrderBy(s => s.Money).Last().OpenSafe();
        }

    }
}
