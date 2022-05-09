/*Mintis buvo ta, kad čia galima sudėti elementus, kurie būtų prieinami ir naudojami atsidarius pagrindinį puslapį. Tačiau norint sutvarkyti visą kodą, juos galbūt reikėtų iškelti į kitas klases, kadangi tiek prisijungti, tiek paieškos laukas ir paieškos mygtukas yra atvaizduojami visoje svetainėje. Galbūt jiems tinkamesnė vieta būtų eurekaVeiksmai...*/

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Pages
{
    internal class eurekaPagrindinisPage : BasePage
    {
        public eurekaPagrindinisPage(IWebDriver webDriver) : base(webDriver) { }

        private const string PageAdress = "https://knygynas.biz/";

        private static IWebElement prisijungtiMygtukas => Driver.FindElement(By.Id("customer_login_link"));
        private static IWebElement paieškosLaukas => Driver.FindElement(By.XPath("//body/div[@id='shopify-section-header']/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/form[1]/input[1]"));
        private static IWebElement paieškosMyktukas => Driver.FindElement(By.XPath("//body/div[@id='shopify-section-header']/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/form[1]/button[1]"));

        public void AtidarytiPagrindinįPuslapį()
        {
            Driver.Url = PageAdress;
        }

        public void ĮvestiĮPaiešką(string knygosPavadinimas) 
        {
            paieškosLaukas.Clear();
            paieškosLaukas.SendKeys(knygosPavadinimas);
        }

        public void PaspaustiPaieškosMygtuką() 
        {
            paieškosMyktukas.Click();
        }

        public void PaspaustiMygtukąPrisijungti()
        {
            prisijungtiMygtukas.Click();
        }
    }

}
