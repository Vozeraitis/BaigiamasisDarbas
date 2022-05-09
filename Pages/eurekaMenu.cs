/*Turbūt sunkiausias ir labiausiai nepavykęs testas iš visų, kuriuos dariau šiai užduočiai. Puslapio idėja - visų Menu elementų ir submenu sąrašų vieta, bei veiksmai, kurie būtų su jais atliekami. */

using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Pages
{
    internal class eurekaMenu : BasePage
    {
        public eurekaMenu(IWebDriver webDriver) : base(webDriver) { }
        
        private const string PageAdress = "https://knygynas.biz/";
        
        //Niekaip nepavyko padaryti, kad pagal CSS selektorių ar paprastą nukopijuotą XPath pasirinktų būtent tuos elementus, kuriuos noriu (Gal dėl to, kad tokie pat elementai naudojami ir mobile menu navigacijai. Todėl teko pasižiūrėti ir pasimokyti, kaip pačiam apsirašyti XPath. Konkrečiai šiuo atveju pasirenkami elementai, kurie savo href'e turi atitinkamą dalį teksto ir yra "wrapper" klasės vaikai (o ne "navigation" klasės, kuri, kiek supratau, naudojama mobile menu))
        public static IReadOnlyCollection<IWebElement> knyguKeliones => Driver.FindElements(By.XPath("//div[@class='wrapper']//a[contains(@data-href, '/collections/knygu-keliones')]"));
        
        public static IWebElement kategorijosPavadinimas => Driver.FindElement(By.XPath("//*[@id='CollectionSection']/header/h1"));
        
        public static string[] knygųKelionesSubmenu = { "Italija", "JAV", "Japonija", "Prancūzija", "Lotynų Amerika", "Kosmosas" };

        //Pagrindinė testo mintis buvo eiti per submenu elementų sąrašą, paspausti ant kiekvieno iš jų ir patikrinti ar adresas atitinka href. Taip turėjo pasitvirtinti, kad tikrai nueita į tą kategoriją. Šito niekaip nepavyko padaryti, metė įvairias klaidas, kurių nesugebėjau išspręsti. Tada nusprendžiau tikrinti kiekvieno aplankyto puslapio antraštę. 
        public void PatikrintiSubmenuJaponija()
        {
            for (int i = 0; i < knyguKeliones.Count; i++)
            {
                IWebElement element = knyguKeliones.ElementAt(i);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView();", element);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
                string sectionHeader = $"Knygų kelionės - {knygųKelionesSubmenu[i]}";
                GetWait(5).Until(d => kategorijosPavadinimas.Displayed);
                //Žinau, kad Thread yra ne pats geriausias ir labai neoptimalus pasirinkimas, tačiau visas šis metodas kitaip tiesiog neveikia. Bandžiau laukti konkrečių elementų, tačiau gaudavau klaidas, kad jie yra stale arba no longer attached to DOM. Nesugebėjau šių klaidų išspręsti. Kita klaida, kurios niekaip nesupratau, buvo ta, jog lyginant rezultatus, expected tapdavo i+1. Gaudavau (ir turėdavau gauti) Italiją, tačiau expected rašydavo Jav. Atliekant Debug viskas atrodė gerai.
                Thread.Sleep(2000);
                Assert.AreEqual(sectionHeader, kategorijosPavadinimas.Text, "Submenu pasirinkimas neveikia");
            }
        }

        
    }
}
