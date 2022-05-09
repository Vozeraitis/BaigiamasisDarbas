using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Tests
{
    internal class eurekaKategorijosTests : BaseTest
    {
        //Testas turėtų išrikuoti pasirinktos kategorijos knygas pagal autorius. Norėjau rikiuoti pagal kainą, taičiau kai kur knygoms pritaikytos nuolaidos ir atvaizduojami skirtingi kainos elementai. Pasirodė per sudėtinga. Value renkamasi du kartus, kadangi užkrovus puslapį selectboxe jau būna pasirinkta "pagal autorių" tačiau rikiavimas nebūna atliktas (matosi žiūrint į url). Scrollinama todėl, kad klaidos screenshote matytųsi rezultatas. Galiausiai lyginami sąrašai. Įdomu tai, kad vienose kategorijose išrikiuojama pagal vardus, kitose - ne.
        [Test]
        public static void RikiavimasPagalAutorius() 
        {
            _eurekaKategorijosPage.AtidarytiPagrindinįPuslapį();
            _eurekaKategorijosPage.SelectFromDropDownByValue("best-selling");
            _eurekaKategorijosPage.SelectFromDropDownByValue("manual");
            _eurekaKategorijosPage.ScrollDown();
            _eurekaKategorijosPage.PalygintiSąrašusAutoriai();
        }

        [Test]
        public static void RikiavimasPagalPavadinimąDidėja() 
        {
            _eurekaKategorijosPage.AtidarytiPagrindinįPuslapį();
            _eurekaKategorijosPage.SelectFromDropDownByValue("title-ascending");
            _eurekaKategorijosPage.PalygintiSąrašusPavadinimai();
        }
    }
}
