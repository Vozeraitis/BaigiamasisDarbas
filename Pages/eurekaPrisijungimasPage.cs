using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Pages
{
    internal class eurekaPrisijungimasPage : BasePage
    {
        public eurekaPrisijungimasPage(IWebDriver webDriver) : base(webDriver) { }

        private const string PageAdress = "https://knygynas.biz/account/login";

        private static IWebElement emailField => Driver.FindElement(By.Id("CustomerEmail"));
        private static IWebElement emailPassword => Driver.FindElement(By.Id("CustomerPassword"));
        private static IWebElement prisijungiButton => Driver.FindElement(By.CssSelector("#customer_login > p:nth-child(9) > input"));
        private static IWebElement atsijungtiButton => Driver.FindElement(By.Id("customer_logout_link"));
        public static IWebElement prisijungimoKlaida => Driver.FindElement(By.CssSelector("#customer_login > div.errors"));



        public void ĮvestiElPaštą(string elpastas) 
        {
            emailField.Clear();
            emailField.SendKeys(elpastas);
        }

        public void ĮvestiSlaptažodį(string slaptazodis)
        {
            emailPassword.Clear();
            emailPassword.SendKeys(slaptazodis);
        }

        public void PaspaustiPrisijungti() 
        {
            GetWait(3).Until(d => prisijungiButton.Displayed);
            prisijungiButton.Click();
        }

        public void PaspaustiAtsijungti()
        {
            GetWait(3).Until(d => atsijungtiButton.Displayed);
            atsijungtiButton.Click();
        }

        public void KlaidosPatvirtinimas() 
        {
            bool expectedResult = prisijungimoKlaida.Displayed;
            Assert.IsTrue(expectedResult, "Klaida pranešant dėl nepavykusio prisijungimo");
        }

        public void PrisijungimoPatvirtinimas() 
        {
            String actualUrl = Driver.Url;
            String expectedUrl = "https://knygynas.biz/account";

            Assert.AreEqual(expectedUrl, actualUrl, "Nepavyksta prisijungti"); 
        }
    }
}
