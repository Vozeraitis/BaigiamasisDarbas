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
        
        //Tame Gride yra išrikiuotos prekės ir pirmoje vietoje turi būti konkrečiai ta prekė, kurios ieškome. Reikia pastebėti, kad paieška puslapyje veikia įdomiai. Net jei nėra konkretaus rezultato, paieška gali turėti rezultatų, kadangi ieškoma ne tik prekių, bet ir jų aprašų (pvz., jei ieškotume žodžių 'kopos'). Čia aprašomas pirmo grido elemento pavadinimas.
        private static IWebElement knygosPavadinimas => Driver.FindElement(By.CssSelector("#ieskoti-1-rezultatas-pagal-uzklausa-kopa > main > div > div > div.grid > div.grid__item.four-fifths > h2 > a"));
        
        //Jeigu paieška nedavė rezultatų, atsiranda naujas gridas, kurio elementas parašo, kad nieko panašaus su įvesta knyga nėra. 
        private static IReadOnlyCollection<IWebElement> paieškaNesėkmingaText => Driver.FindElements(By.XPath("//body/main[1]/div[1]/div[1]/div[1]/h1"));

        public void PasirinktiKnygą() 
        {
            knygosPavadinimas.Click();
        }

        //Testas patikrina abu gridus. Jei prekių sąrašas yra ne tuščias, tai tada tikrinamas pirmo elemento pavadinimas. Tai gali būti kitokia knyga, negu nurodyta, todėl atsiradusi klaida parodo, kad rezultatų yra, tačiau nerasta knyga konkrečiu pavadinimu. Jei gridas tuščias, tai reiškia kad nėra jokių rezultatų, tikrinama, ar pasirodo tekstas, kuris apie tai informuoja (ar antras gridas nėra tuščias).
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
