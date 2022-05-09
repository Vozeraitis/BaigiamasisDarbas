using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Tests
{
    internal class eurekaKrepšelisTests : BaseTest
    {
        //Pats ilgiausias testas, kurį būtų galima suskaidyti į kelias dalis, bet norėjau pabandyti padaryti šiek tiek ilgesnį. Tikrinamas kelias nuo knygos pasirinkimo iki bandymo apmokėti, nepasirinkus, kad yra sutinkama su taisyklėmis ir nuostatomis.
        [TestCase("Kopa", "Prieš pereidami prie atsiskaitymo turite sutikti su taisyklėmis.")]
        public void TaisykliųPatvirtinimas(string knygosPavadinimas, string taisyklėsAlert) 
        {
            _eurekaPagrindinisPage.AtidarytiPagrindinįPuslapį();
            _eurekaPagrindinisPage.ĮvestiĮPaiešką(knygosPavadinimas);
            _eurekaPagrindinisPage.PaspaustiPaieškosMygtuką();
            _eurekaPaieška.PasirinktiKnygą();
            _eurekaVeiksmai.paspaustiPirktiMygtuką();
            _eurekaVeiksmai.paspaustiKrepšelioMygtuką();
            _eurekaKrepšelisPage.PrekiųKiekioTikrinimas("1");
            _eurekaKrepšelisPage.PasirinktiAtsiimtiKnygyne();
            _eurekaKrepšelisPage.PereitiPrieMokėjimo();
            _eurekaKrepšelisPage.PažymėkiteTaisyklesIrNuostatasAlert(taisyklėsAlert);

        }

    }
}
