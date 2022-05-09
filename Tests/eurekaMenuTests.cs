using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Tests
{
    internal class eurekaMenuTests : BaseTest
    {
        //Šiame teste žingsniai tik du, tačiau pačiame SubMenu tikrinime savotiškai įrašyti du žingsniai :) 
        [Test]
        public static void KnyguKelionesKategorijos()
        {
            _eurekaPagrindinisPage.AtidarytiPagrindinįPuslapį();
            _eurekaMenu.PatikrintiSubmenuJaponija();
        }
    }
}
