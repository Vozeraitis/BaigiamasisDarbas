using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace baigiamasisDarbas.Tests
{
    internal class eurekaLoginTest : BaseTest
    {
        //Šiuose testuose Thredai naudojami tam, kad būtų apgaunama captcha. Kitaip viskas atliekama labai greitai ir svetainė supranta, kad joje lankosi automatas.
        [Test]
        public static void TestLogin()
        {
            _eurekaPagrindinisPage.AtidarytiPagrindinįPuslapį();
            _eurekaPagrindinisPage.PaspaustiMygtukąPrisijungti();
            Thread.Sleep(3000);
            _eurekaPrisijungimasPage.ĮvestiElPaštą("giwoja8898@chokxus.com");
            _eurekaPrisijungimasPage.ĮvestiSlaptažodį("knygostest");
            Thread.Sleep(10000);
            _eurekaPrisijungimasPage.PaspaustiPrisijungti();
            _eurekaPrisijungimasPage.PrisijungimoPatvirtinimas();
            _eurekaPrisijungimasPage.PaspaustiAtsijungti();
            
        }

        [Test]
        public static void TestWrongEmail()
        {
            _eurekaPagrindinisPage.AtidarytiPagrindinįPuslapį();
            _eurekaPagrindinisPage.PaspaustiMygtukąPrisijungti();
            Thread.Sleep(3000);
            _eurekaPrisijungimasPage.ĮvestiElPaštą("giwoja8898@chokxuscom");
            _eurekaPrisijungimasPage.ĮvestiSlaptažodį("knygostest");
            Thread.Sleep(10000);
            _eurekaPrisijungimasPage.PaspaustiPrisijungti();
            _eurekaPrisijungimasPage.KlaidosPatvirtinimas();
        }

    }
}
