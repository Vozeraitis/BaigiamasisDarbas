using baigiamasisDarbas.Pages;
using baigiamasisDarbas.Pages.Bendri_veiksmai;
using baigiamasisDarbas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Tests
{
    internal class BaseTest
    {
        protected static IWebDriver Driver;

        public static eurekaPagrindinisPage _eurekaPagrindinisPage;
        public static eurekaPrisijungimasPage _eurekaPrisijungimasPage;
        public static eurekaKategorijosPage _eurekaKategorijosPage;
        public static eurekaPaieška _eurekaPaieška;
        public static eurekaKrepšelisPage _eurekaKrepšelisPage;
        public static eurekaVeiksmai _eurekaVeiksmai;
        public static eurekaMenu _eurekaMenu;


        [OneTimeSetUp]
        public static void OneTimeSetUp() 
        {
            Driver = new FirefoxDriver();

            _eurekaPagrindinisPage = new eurekaPagrindinisPage(Driver);
            _eurekaPrisijungimasPage = new eurekaPrisijungimasPage(Driver);
            _eurekaKategorijosPage = new eurekaKategorijosPage(Driver);
            _eurekaPaieška = new eurekaPaieška(Driver);
            _eurekaKrepšelisPage = new eurekaKrepšelisPage(Driver);
            _eurekaVeiksmai = new eurekaVeiksmai(Driver);
            _eurekaMenu = new eurekaMenu(Driver);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown() 
        {
            Driver.Quit();
        }

        [TearDown]
        public static void TearDown() 
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                EkranoVaizdai.TakeScreenshot(Driver);
            }
        }
    }
}
