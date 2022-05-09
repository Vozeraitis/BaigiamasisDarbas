/*Aprašomi elementai ir veiksmai, atliekami atidarius prekių krepšelį, bet dar nenuėjus iki mokėjimo lango*/

using Microsoft.Graph;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Pages
{
    internal class eurekaKrepšelisPage : BasePage
    {
        public eurekaKrepšelisPage(IWebDriver webDriver) : base(webDriver) { }

        private const string PageAdress = "https://knygynas.biz/cart";

        private static IWebElement prekėKrepšelyje => Driver.FindElement(By.XPath("//body/main[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[3]/div[1]/div[1]/div[1]/div[2]"));
        private static IWebElement prekiųKiekisKrepšelyje => Driver.FindElement(By.XPath("//input[@class='cart__quantity-selector']"));
        private static IWebElement atsiimtiKnygyneMygtukas => Driver.FindElement(By.XPath("//*[@id='parcelyWidget']/div/div/div[3]/span[1]/span[1]"));
        private static IWebElement mokėtiMygtukas => Driver.FindElement(By.XPath("//button[contains(text(),'Pereiti prie mokėjimo')]"));

        //Pasirinkimai kraunasi šiek tiek ilgiau, tad sėkmingam testui reikia palaukti, kol užsikraus visi pasirinkimai. Su įprastu Click metodu nepavyko paspausti šio mygtuko, tad teko naudoti IJavaScriptExecutor. Veikia.
        public void PasirinktiAtsiimtiKnygyne() 
        {
            GetWait(10).Until(c => atsiimtiKnygyneMygtukas.Displayed);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", atsiimtiKnygyneMygtukas);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", atsiimtiKnygyneMygtukas);
        }

        public void PereitiPrieMokėjimo()
        {
            GetWait(5).Until(c => mokėtiMygtukas.Displayed);
            mokėtiMygtukas.Click();
        }


        public void ElementoPavadinimoTikrinimas(string pavadinimas) 
        {
            string expected = pavadinimas.ToLower();
            string actual = prekėKrepšelyje.Text.ToLower();
            Assert.AreEqual(expected, actual, "Prekės pavadinimas neatitinka");
        }

        public void PrekiųKiekioTikrinimas(string kiekis)
        {
            string actual = prekiųKiekisKrepšelyje.GetAttribute("value");
            Console.WriteLine(actual);
            Assert.AreEqual(kiekis, actual, "Prekių kiekis neatitinka");
        }

        //Teste, kur naudojamas šis metodas, yra tikrinama, ar nepažymėjus sutikimo su taisyklėmis atsiranda įspėjimas ir ar jo tekstas atitinka tą, kuris ir turėtų atitikti. Metodui paduodamas parametras - įspėjimo testas.
        public void PažymėkiteTaisyklesIrNuostatasAlert(string alertText)
        {
            try
            {
                string text = GetWait(5).Until(d => Driver.SwitchTo().Alert().Text);

                Assert.IsTrue(text.Contains(alertText), "Neatitinka pranešimas");
            }    
            catch (NoAlertPresentException)
            {
                Console.WriteLine("Klaida");
            }   
        }
    }
}
