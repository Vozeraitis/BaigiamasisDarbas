/*Vienos iš kategorijų puslapis. Pirma mintis buvo turėti vieną kategorijos puslapį, kurį būtų galima panaudoti tuos pačius veiksmus atliekant visose kategorijose, bet nepavyko, tad čia įdėta, atidaroma ir tikrinama viena konkreti kategorija.*/

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
    internal class eurekaKategorijosPage : BasePage
    {
        public eurekaKategorijosPage(IWebDriver webDriver) : base(webDriver) { }

        private const string PageAdress = "https://knygynas.biz/collections/knygu-keliones-Japonija";
        private SelectElement sortBy => new SelectElement(Driver.FindElement(By.Id("SortBy")));
        private static IReadOnlyCollection<IWebElement> authors => Driver.FindElements(By.XPath("//h4[@class='author']"));
        private static IReadOnlyCollection<IWebElement> titles => Driver.FindElements(By.XPath("//p[@class='grid-link__title']"));

        public void AtidarytiPagrindinįPuslapį()
        {
            Driver.Url = PageAdress;
        }

        public void SelectFromDropDownByValue(string value)
        {
            sortBy.SelectByValue(value);
        }

        public void ScrollDown() 
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,950)", "");
        }

        //Iš pradžių užkraunamas puslapis ir paimamas autorių listas (authors). Tada einama per kiekvieną elementą ir jo tekstas yra įdedamas į stringų listą (authorsnames). Kadangi šis žingsnis atliekamas jau po to, kai elementai būna išrikiuoti svetainėje, viduje sukuriamas dar vienas tų pačių elementų listas. Tada iteruojama per kiekvieną jo elementą ir sukuriamas naujas stringų listas (expectedResults). Galiausiai abu listai palyginami iki pirmo nesutapimo. Taip pat daroma ir su autorių vardais ir su pavadinimais. Galvojau, kaip padaryti, kad būtų vienas lyginimas, kuriam galėtume paduoti visus parametrus, bet nespėjau sukurti taip, kad veiktų, todėl palyginimui tiesiog padariau antrą metodą, kuris lygina pavadinimus tuo pačiu principu. 
        public void PalygintiSąrašusAutoriai() 
        {

            List<String> authorsNames = new List<string>();
            foreach (IWebElement author in authors)
            {
                authorsNames.Add(author.Text);
            }
            authorsNames.Sort();
            IReadOnlyCollection<IWebElement> sortedAuthors = Driver.FindElements(By.XPath("//h4[@class='author']"));
            List<String> expectedResults = new List<string>();
            foreach (IWebElement sortedAuthor in sortedAuthors)
            {
                expectedResults.Add(sortedAuthor.Text);
            }
            Assert.AreEqual(authorsNames, expectedResults, "Rikiavimas neveikia");

        }

        public void PalygintiSąrašusPavadinimai()
        {

            List<String> titlesAscending = new List<string>();
            foreach (IWebElement title in titles)
            {
                titlesAscending.Add(title.Text);
            }
            titlesAscending.Sort();
            IReadOnlyCollection<IWebElement> sortedTitles = Driver.FindElements(By.XPath("//p[@class='grid-link__title']"));
            List<String> expectedResults = new List<string>();
            foreach (IWebElement sortedAuthor in sortedTitles)
            {
                expectedResults.Add(sortedAuthor.Text);
            }
            Assert.AreEqual(titlesAscending, expectedResults, "Rikiavimas neveikia");

        }

    }
}
