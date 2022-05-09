using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Pages
{
    internal class eurekaPaieška : BasePage
    {
        public eurekaPaieška(IWebDriver webDriver) : base(webDriver) { }
        
        //Gridas, kuriame atsiranda prekės, įsijungus paieškos rezultatų laukui.
        private static IReadOnlyCollection<IWebElement> prekiųSąrašas => Driver.FindElements(By.XPath("//body/main[1]/div[1]/div[1]/div[2]")); 
        
        private static IWebElement knygosPavadinimas => Driver.FindElement(By.CssSelector("#ieskoti-1-rezultatas-pagal-uzklausa-kopa > main > div > div > div.grid > div.grid__item.four-fifths > h2 > a"));
        
        //Jeigu paieška nedavė rezultatų, atsiranda naujas gridas, kurio elementas parašo, kad nieko panašaus su įvesta knyga nėra. 
        private static IReadOnlyCollection<IWebElement> paieškaNesėkmingaText => Driver.FindElements(By.XPath("//body/main[1]/div[1]/div[1]/div[1]/h1"));

        public void PasirinktiKnygą() 
        {
            knygosPavadinimas.Click();
        }

        public void PrekeEgzistuoja(string pavadinimas) 
        {
            if (prekiųSąrašas.Count > 0)
            {
                Assert.AreEqual(knygosPavadinimas.Text.ToLower(), pavadinimas.ToLower(), "Nerasta knyga konkrečiu pavadinimu");
            }
            else
            {
                Assert.IsTrue(paieškaNesėkmingaText.Count > 0, "Klaida pranešant apie paiešką");
            }
        }
    }
}
