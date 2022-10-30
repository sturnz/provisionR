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
    public class ProvisionsrechnerTests
    {
        [TestMethod()]
        public void BerechneProvision_Sparte_Is_Null()
        {   
            // arrange
            var provisionsrechner = new Provisionsrechner(30);
            string sparte    = null;
            string beitrag   = "100";
            string zahlweise = "monatlich";

            // act
            var result = provisionsrechner.BerechneProvision(sparte, beitrag, zahlweise);
            
            // assert
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void BerechneProvision_Beitrag_Is_Null()
        {
            // arrange
            var provisionsrechner = new Provisionsrechner(30);
            string sparte = "HR";
            string beitrag = null;
            string zahlweise = "monatlich";

            // act
            var result = provisionsrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void BerechneProvision_Zahlweise_Is_Null()
        {
            // arrange
            var provisionsrechner = new Provisionsrechner(30);
            string sparte = "HR";
            string beitrag = "100";
            string zahlweise = null;

            // act
            var result = provisionsrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void BerechneProvision_HR_100_monatlich()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "HR";
            string beitrag = "100";
            string zahlweise = "monatlich";
            var expected = "301,86";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void BerechneProvision_HR_100_vierteljährlich()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "HR";
            string beitrag = "100";
            string zahlweise = "vierteljährlich";
            var expected = "100,62";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void BerechneProvision_HR_100_halbjährlich()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "HR";
            string beitrag = "100";
            string zahlweise = "halbjährlich";
            var expected = "50,31";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void BerechneProvision_HR_100_jährlich()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "HR";
            string beitrag = "100";
            string zahlweise = "jährlich";
            var expected = "25,15";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void BerechneProvision_WG_100_monatlich()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "WG";
            string beitrag = "100";
            string zahlweise = "monatlich";
            var expected = "299,70";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void BerechneProvision_WG_100_vierteljährlich()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "WG";
            string beitrag = "100";
            string zahlweise = "vierteljährlich";
            var expected = "99,90";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void BerechneProvision_WG_100_halbjährlich()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "WG";
            string beitrag = "100";
            string zahlweise = "halbjährlich";
            var expected = "49,95";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void BerechneProvision_WG_100_jährlich()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "WG";
            string beitrag = "100";
            string zahlweise = "jährlich";
            var expected = "24,98";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void BerechneProvision_Beitrag_Is_String()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "WG";
            string beitrag = "string";
            string zahlweise = "jährlich";
            var expected = "24,98";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);
        }

        [TestMethod()]
        public void BerechneProvision_Beitrag_Is_Double()
        {
            // arrange
            var provisionrechner = new Provisionsrechner(30);
            string sparte = "WG";
            string beitrag = "100,00";
            string zahlweise = "jährlich";
            var expected = "24,98";

            // act
            var actual = provisionrechner.BerechneProvision(sparte, beitrag, zahlweise);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void BerechneProvision_Beitrag_Mit_Dezimalpunkt()
        {
            Assert.Fail();
        }


    }
}