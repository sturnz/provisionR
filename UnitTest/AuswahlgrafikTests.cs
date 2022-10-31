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
    public class AuswahlgrafikTests
    {
        [TestMethod()]
        public void PrintTest()
        {
            // arrange
            var sut         = new Auswahlgrafik();
            string expected = "Neuen Kunden anlegen\nNeuen Vertrag anlegen\nKundenliste anschauen\nVertragsliste anschauen";

            // act
            string actual   = sut.Print("VertragsHeader");

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}