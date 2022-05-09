/*Klasė skirta veiksmams ir elementams, kurių nepavyko logiškai priskirti kažkuriai vienai klasei ar vienam puslapiui. Bent tokia buvo pirminė idėja */

using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Pages.Bendri_veiksmai
{
    internal class eurekaVeiksmai : BasePage
    {
        public eurekaVeiksmai(IWebDriver webDriver) : base(webDriver) { }
        //Aprašomas mygtukas, kuris atsiranda tik pasirinkus ir įsijungus kažkurios prekės puslapį. Galima perkelti, apsirašyti ir naudoti iš atskiros "Produktai" klasės.
        public IWebElement pirktiMygtukas => Driver.FindElement(By.XPath("//button[@id='AddToCart']"));
        //Mygtukas viršutinėje juostoje, nuoroda į krepšelį. Krepšelį galima pasiekti ir per kitą mygtuką, kuris šiame darbe nenaudojamas.
        public IWebElement krepšelisMygtukas => Driver.FindElement(By.XPath("//body/div[@id='shopify-section-header']/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/a[1]"));

        public void paspaustiPirktiMygtuką() 
        {
            GetWait(5).Until(c => pirktiMygtukas.Displayed);
            pirktiMygtukas.Click();
        }

        //.Enabled naudojama todėl, kad atliekant Krepšelio testą, paspaudžiamas mygtukas pirkti ir jis trumpam yra nepaspaudžiamas, kol prekė įdedama į krepšelį. Tada mygtukas vėl tampa Enabled. Testas vyksta per greitai, todėl pasiekiamas tuščias krepšelis arba išmetama klaida. Su pirktiMygtukas.Enabled veikia.
        public void paspaustiKrepšelioMygtuką()
        {
            GetWait(5).Until(c => pirktiMygtukas.Enabled);
            krepšelisMygtukas.Click();
        }
    }
}
