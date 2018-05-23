using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wallet;
using System.IO;
using Moq;

namespace Test
{
    [TestClass]
    public class TestMoneyConsole
    {
        MoneyPrinterConsole console;

        [TestInitialize]
        public void TestInitialize()
        {
            console = new MoneyPrinterConsole();
            
        }

        [TestMethod]
        public void PrintTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                console.Print("add", "RUB", 300);
                Assert.AreEqual<string>("add RUB 300", sw.ToString());

            }
            
        }
    }
}
