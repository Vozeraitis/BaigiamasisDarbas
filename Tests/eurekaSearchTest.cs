using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Tests
{
    internal class eurekaSearchTest : BaseTest
    {
        //Tikrinama, ar paieška veikia tinkamai įvedus tiek tokį žodį, kuris duotų konkrečią knygą, tiek tokį, kuris neduotų jokių paieškos rezultatų.
        [TestCase("Kopa", TestName = "Prekė egzistuoja")]
        [TestCase("Kpsgsgge", TestName = "Paieška nedavė rezultatų")]
        public static void TiksliPrekėsPaieška(string knygosPavadinimas) 
        {
            _eurekaPagrindinisPage.AtidarytiPagrindinįPuslapį();
            _eurekaPagrindinisPage.ĮvestiĮPaiešką(knygosPavadinimas);
            _eurekaPagrindinisPage.PaspaustiPaieškosMygtuką();
            _eurekaPaieška.PrekeEgzistuoja(knygosPavadinimas);
        }
    }
}
