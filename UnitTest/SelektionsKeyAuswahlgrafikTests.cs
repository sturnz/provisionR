using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jasmin1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasmin1.Tests
{
    [TestClass()]
    public class SelektionsKeyAuswahlgrafikTests
    {
        [TestMethod()]
        public void PrintTest()
        {
            // arrange
            var csvHeaderFactory    = new CsvHeaderFactory();
            var sut                 = new SelektionsKeyAuswahlgrafik(csvHeaderFactory);
            string expected         = "KNR\nNachname\nVorname\nVNR\nDatum\nSparte\nBeitrag\nZahlweise\nProvision Partner";

            // act
            string actual           = sut.Print("VertragsHeader");

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}